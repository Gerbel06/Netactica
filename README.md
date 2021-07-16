# Prueba NETACTICA 
 NETACTICA - Gerardo Beltran Pulido
 

# Requerimientos
Visual Studio 2019
SQL SERVER
Crear la base de datos Sql server mediante el script de las fuentes
Modificar el web.config por el usuario de su base de datos 


# Documentacion del APi

El api tiene la documentacion autogenerada en la ruta /Help

![image](https://user-images.githubusercontent.com/36347245/126008525-5ad78863-73c4-46b1-bd77-4951ce2d8d37.png)


# NOTA
Todas los consumos de las api tienen autorizacion por JWT, es decir que tiene que crear un token mediante el api enviando el correo y la contrasena.
debe enviar el token en el header en el parametro Authorization @token_type + "" + @access_token

# Ejemplo envio token

![image](https://user-images.githubusercontent.com/36347245/126008335-a902971e-3135-43c8-b502-04aca2659bef.png)


# Ejemplo flujo 
### Crear Usuario
![image](https://user-images.githubusercontent.com/36347245/126008071-f68cc8f4-ba42-46f2-8d5b-6e424dda2978.png)


### Obtener token
![image](https://user-images.githubusercontent.com/36347245/126008108-042cfee9-460e-44f3-bd55-9173bd569f5f.png)


### Ejemplo consumo api sin token

![image](https://user-images.githubusercontent.com/36347245/126008191-5f3b8547-241c-437c-9f07-5823a5d6e5ac.png)

### Ejemplo del consumo del api con token

![image](https://user-images.githubusercontent.com/36347245/126008697-d40aaa98-6732-4405-a434-d6a00c4dba04.png)

### Validacion creacion vuelo 

![image](https://user-images.githubusercontent.com/36347245/126008728-09d8d09c-4012-47b1-b2c1-9be4eb9aa798.png)

### Crear Reserva

![image](https://user-images.githubusercontent.com/36347245/126008951-9ff294ca-57ef-4ba7-972f-865d16a39b42.png)

### Crear Reserva

![image](https://user-images.githubusercontent.com/36347245/126009219-b6d33b2f-6821-4748-8195-7739c3d26ba6.png)

### Buscar Reserva

![image](https://user-images.githubusercontent.com/36347245/126008809-33fc97b0-2b29-4f17-b8ac-75c48a2ca3fb.png)

### Filtro Reserva

Para el parametro id column de la peticion tener en cuenta:

1 IdReserva 
2 IdVuelo
3 FechaLlegada
4 AeropuertoOrigen
5 AeropuertoDestino
6 Aerolinea
7 IdCliente
 8 Precio

![image](https://user-images.githubusercontent.com/36347245/126009161-e1494f70-7f05-4187-a47d-af2a0f7b6e9b.png)
