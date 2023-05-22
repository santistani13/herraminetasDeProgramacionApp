# herraminetasDeProgramacionApp
app para herramientas de programacion

# Equipos de futbol

Aplicacion corrida en dotnet, que se basa en dos tablas donde una estan los equipos de futbol a nivel mundial y otra tabla las ligas del mundo adonde estos equipos pertenecen. Existe una relacion entre ambas tablas con la liga misma del equipo.

## Prerequisites e instalaciones 

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

