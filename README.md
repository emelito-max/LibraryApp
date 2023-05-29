# LibraryApp

### Running the application locally

1. build the docker image
2. run the docker compose file
3. access the **App** at http://localhost:4000/

### Access the Database

Database is mapped to port 4002 on the host machine. Internally the database is running on port 5432   
and can be accessed using the following credentials:  
`DB Name: postgres`    
`Username: postgres`  
`Password: postgres`

### Access PGAdmin to view the database

1. Access the PGAdmin at http://localhost:4003
2. Right click on the *Servers* and select *Create -> Server*
3. Enter the following details:
4. Name: **[Name of your Database]**
5. Host name/address: **172.20.1.2**  Port: **5432**
6. Add the Database credentials to build a connection
