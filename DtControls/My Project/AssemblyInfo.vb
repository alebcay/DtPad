Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Resources

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
#If CONFIG = "Debug" Then
<Assembly: AssemblyDescription("Marco Macciò - diariotraduttore.com")> 
<Assembly: AssemblyCompany("Diario di un traduttore")> 
#End If

#If CONFIG = "Release" Then
    <Assembly: AssemblyDescription("Marco Macciò - diariotraduttore.com")> 
    <Assembly: AssemblyCompany("Diario di un traduttore")> 
#End If

#If CONFIG = "ReleaseFE" Then
    <Assembly: AssemblyDescription("Marco Macciò")> 
    <Assembly: AssemblyCompany("")> 
#End If

<Assembly: AssemblyTitle("DtControls")> 
<Assembly: AssemblyConfiguration("110713")> 
<Assembly: AssemblyProduct("DtControls")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: AssemblyCulture("")> 

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("7948c941-fe8b-4c32-bb16-c2be6ecccc08")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
<Assembly: AssemblyVersion("0.2.1.40")> 
<Assembly: AssemblyFileVersion("0.2.1.40")> 
<Assembly: NeutralResourcesLanguage("en-GB")> 
<Assembly: CLSCompliant(True)> 
