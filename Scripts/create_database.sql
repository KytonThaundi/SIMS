-- PostgreSQL database creation script for SIMS Web application

-- Connect to postgres database to create our new database
\c postgres postgres

-- Create the database
CREATE DATABASE sims
    WITH
    OWNER = postgres
    TEMPLATE = template0
    ENCODING = 'UTF8'
    LC_COLLATE = 'C.UTF-8'
    LC_CTYPE = 'C.UTF-8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- Connect to the newly created database
\c sims postgres

-- Create extensions if needed
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
