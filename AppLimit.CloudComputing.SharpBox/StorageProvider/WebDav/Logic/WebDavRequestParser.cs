using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using AppLimit.CloudComputing.SharpBox.StorageProvider.BaseObjects;
using AppLimit.CloudComputing.SharpBox.StorageProvider.API;
using AppLimit.CloudComputing.SharpBox.Common.IO;

namespace AppLimit.CloudComputing.SharpBox.StorageProvider.WebDav.Logic
{
    internal class WebDavRequestParser
    {
        public static List<BaseFileEntry> CreateObjectsFromNetworkStream(Stream data, IStorageProviderService service, IStorageProviderSession session)
        {
            WebDavConfiguration config = session.ServiceConfiguration as WebDavConfiguration;

            List<BaseFileEntry> fileEntries = new List<BaseFileEntry>();

            try
            {
                String resourceName = String.Empty;
                long resourceLength = 0; 
                DateTime resourceModificationDate = DateTime.Now;
                DateTime resourceCreationDate = DateTime.Now;
                Boolean bIsHidden = false;
                Boolean bIsDirectory = false;                                

                XmlTextReader reader = new XmlTextReader(data);    
                while (reader.Read())    
                {
                    switch(reader.NodeType)
                    {                        
                        case XmlNodeType.Element:
                            {                                       
                                // we are on an element and we have to handle this elements
                                String currentElement = reader.Name;                                

                                // we found a resource name
                                if (currentElement.Contains(":href"))
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // go one more step
                                    reader.Read();
                                
                                    // get the name
                                    String nameBase = reader.Value;

                                    // remove the base url
                                    if ( nameBase.StartsWith(config.ServiceLocator.ToString()))
                                    {
                                        nameBase = nameBase.Remove(0, config.ServiceLocator.ToString().Length);
                                    }

                                    // trim all trailing slashes
                                    nameBase = nameBase.TrimEnd('/');
                                    
                                    // get the last file or directory name
                                    PathHelper ph = new PathHelper(nameBase);
                                    resourceName = ph.GetFileName();

                                    // unquote name 
                                    resourceName = Uri.EscapeDataString(resourceName); //HttpUtility.UrlDecode(resourceName);                                    
                                } 
                                else if (currentElement.Contains(":ishidden"))
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // go one more step
                                    reader.Read();

                                    // try to parse
                                    int iIsHidden = 0;
                                    if (!int.TryParse(reader.Value, out iIsHidden))
                                    {
                                        iIsHidden = 0;
                                    }

                                    // convert
                                    bIsHidden = Convert.ToBoolean(iIsHidden);                                    
                                }
                                else if (currentElement.Contains(":getcontentlength"))
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // go one more step
                                    reader.Read();

                                    // read value
                                    if (!long.TryParse(reader.Value, out resourceLength))
                                    {
                                        resourceLength = -1;
                                    }                                    
                                }
                                else if (currentElement.Contains(":creationdate"))                             
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // go one more step
                                    reader.Read();

                                    // parse
                                    if (!DateTime.TryParse(reader.Value, out resourceCreationDate))
                                    {
                                        resourceCreationDate = DateTime.Now;
                                    }                                    
                                }
                                else if (currentElement.Contains(":getlastmodified"))
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // go one more step
                                    reader.Read();

                                    // parse
                                    if (!DateTime.TryParse(reader.Value, out resourceModificationDate))
                                    {
                                        resourceModificationDate = DateTime.Now;
                                    }                                    
                                }
                                else if (currentElement.Contains(":collection"))
                                {
                                    // check if it is an element with valud namespace prefix
                                    if (!CheckIfNameSpaceDAVSpace(currentElement, reader))
                                    {
                                        continue;
                                    }

                                    // set as directory
                                    bIsDirectory = true;
                                }
                                
                                // go ahead
                                break;
                            }

                        case XmlNodeType.EndElement:
                            {
                                // handle the end of an response
                                if (!reader.Name.ToLower().Contains( ":response"))
                                {
                                    break;
                                }

                                // check if it is an element with valud namespace prefix
                                if (!CheckIfNameSpaceDAVSpace(reader.Name, reader))
                                {
                                    continue;
                                }

                                // handle the end of an response, this means
                                // create entry
                                BaseFileEntry entry;

                                if (bIsDirectory)
                                {
                                    entry = new BaseDirectoryEntry(resourceName, resourceLength, resourceModificationDate, service, session);
                                }
                                else
                                {
                                    entry = new BaseFileEntry(resourceName, resourceLength, resourceModificationDate, service, session);
                                }

                                entry.SetPropertyValue("CreationDate", resourceCreationDate);
						
								if (!bIsHidden)
								{
								    fileEntries.Add(entry);
								}

                                // reset all state properties
                                resourceName = String.Empty;
                                resourceLength = 0;
                                resourceModificationDate = DateTime.Now;
                                resourceCreationDate = DateTime.Now;
                                bIsHidden = false;
                                bIsDirectory = false;

                                // go ahead
                                break;
                            }
                        default:
                            {                             
                                break;
                            }
                    }                    
                }                                   
            }
            catch (Exception)
            {                                
            }

            return fileEntries;
        }    

        /// <summary>
        /// This method checks if the attached 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static bool CheckIfNameSpaceDAVSpace(String element, XmlTextReader reader)
        {
            // split the element into tag and field
            String[] fields = element.Split(':');
           
            // could be that the element has no namespace attached, so it is not part
            // of the webdav response
            if (fields.Length == 1)
            {
                return false;
            }

            // get the namespace list
            IDictionary<String, String> nameSpaceList = reader.GetNamespacesInScope(XmlNamespaceScope.All);
            
            // get the namespace of our node
            if (!nameSpaceList.ContainsKey(fields[0]))
            {
                return false;
            }

            // get the value
            String NsValue = nameSpaceList[fields[0]];

            // compare if it's a DAV namespce
            return NsValue.ToLower().Equals("dav:");
        }              
    }    
}
