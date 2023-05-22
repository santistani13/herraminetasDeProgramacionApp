# herraminetasDeProgramacionApp
app para herramientas de programacion

# Equipos de futbol <img src='https://github.com/santistani13/herraminetasDeProgramacionApp/assets/76953005/8a34e328-9a16-4d9c-a316-ba55222b6bd6
' width='25'>

Aplicacion corrida en dotnet, que se basa en dos tablas donde una estan los equipos de futbol a nivel mundial y otra tabla las ligas del mundo adonde estos equipos pertenecen. Existe una relacion entre ambas tablas con la liga misma del equipo.

## Pre requisites e instalaciones <img src='https://github.com/santistani13/herraminetasDeProgramacionApp/assets/76953005/18cac3e0-c101-4641-8004-4839e0337a56' width='25'>




Se necesita instalar dotnet, y entity framework. A continuacion los comandos para todas las instalaciones 

```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
Los dos primeros comandos la instalacion es de manera global, y los otros 4 son de manera local en el proyecto.

### Running the app!

Para correr la aplicacion se puede correr con el comando dotnet run, o si se van a hacer cambios no criticos en el codigo se puede utilizar el comando dotnet watch para que actualice estos mismos automanticamente.
--
dotnet run
dotnet watch
--

## Built With

* https://dotnet.microsoft.com/en-us/ - Dotnet
* https://learn.microsoft.com/en-us/ef/ - entity framework
* https://www.sqlite.org/index.html - Sql lite

