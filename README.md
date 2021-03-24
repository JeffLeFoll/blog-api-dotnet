# blog-api-dotnet

API Blog naive, en dotNet cette fois :)  
(Basée sur [blog formation backend Java](https://github.com/Avalon-Lab/blog-formation-backend))

## Description

A dotNet REST Api that provides services for a blog.

This repository is used to make web (frontend) workshop easier with a working Api.

The project is developed in dotNet core 5.x.

We use MongoDB ([Link](https://www.mongodb.com)) as data base.

The definition of the routes:
```                               
GET    /                                   
GET    /api/blogpost                       
POST   /api/blogpost                        
PUT    /api/blogpost                        
GET    /api/blogpost/:id                   
DELETE /api/blogpost/:id                    
DELETE /api/blogpost                        
GET    /api/blogpost/autor/:name            
```

The swagger is available in developement mode : https://localhost:5001/swagger/index.html