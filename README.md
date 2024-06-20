### Version

`.Net 8`

### Pasos para proyecto api

#### 1. Agregar la cadena de conexion al appsetting.json, la  conexion es similar al siguiente

`"DefaultConnectionString": "Server=;Database=Sales;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true"`

#### 2. En la raiz de la solucion ejecutar el comando para crear la base de datos mediante las migraciones:

`dotnet ef database update --context SalesContext --startup-project .\Sales.Api\ --project .\Sales.Infraestructure`

#### 3. Ejecutar el comando para correr el proyecto api en la ruta base del mismo

`dotnet run`

##### Al final deberia verse de la siguiente manera

![imagen](https://github.com/HectorReyes117/sales-project/assets/86540632/19471b38-50aa-4ed2-a7dd-28444863b3f5)


### Pasos para proyecto WebApp

#### 1. En la carpeta base del proyecto WebApp ejecutar el siguiente comando para instalar los nodemodules

`npm install`

#### 2. ejecutar el comando para ejecutar el proyecto 

`dotnet run`

##### Al final deberia quedar de la siguiente manera

![imagen](https://github.com/HectorReyes117/sales-project/assets/86540632/d6a77b47-f929-4e29-9929-9eac8413e93c)

![imagen](https://github.com/HectorReyes117/sales-project/assets/86540632/f4f81019-a158-4db6-8258-a63665773a7c)



