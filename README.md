# DatabaseAndAccess

Assignment 6
Create a database and access it.

## Table of Contents
- [Features](#features)
- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)

## Features

### Models:
- POCO classes with properties to represent each model

### Repositories
- Customer queries:
    - Get all customers
    - Get a snapshot of customers based on given limit and offset
    - Get a specific customer by ID
    - Get a specific customer by name
    - Add a new customer
    - Update existing cutomer
    - Get the number of costumers in each country
    - Get customers who are the highest spenders in descending order
    - Get a customer's top genre based on invoices

## Install
- Clone 
- Open in Visual Studio
- Go to DataAccess/ConnectionHelper.cs -> Change DataSource in GetConnectionString() to your own db connection.
- Open SSMS and run script to create the sample database Chinook.
    - Script can be found here: https://github.com/lerocha/chinook-database/blob/master/ChinookDatabase/DataSources/Chinook_SqlServer.sql  
- Build the application

## Usage
- Run the application from Visual Studio.

## Maintainers
- Mia Kristiansen
- Alexander Maaby