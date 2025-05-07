#!/bin/bash

# Database initialization script for SIMS Web application
# This script runs all the necessary SQL scripts to initialize the database

echo "Starting database initialization..."

# Create the database
echo "Creating database..."
psql -U postgres -f Scripts/create_database.sql

# Check if database creation was successful
if [ $? -ne 0 ]; then
    echo "Error: Database creation failed."
    exit 1
fi

# Create tables
echo "Creating tables..."
psql -U postgres -f Scripts/create_tables.sql

# Check if table creation was successful
if [ $? -ne 0 ]; then
    echo "Error: Table creation failed."
    exit 1
fi

# Seed data
echo "Seeding initial data..."
psql -U postgres -f Scripts/seed_data.sql

# Check if data seeding was successful
if [ $? -ne 0 ]; then
    echo "Error: Data seeding failed."
    exit 1
fi

echo "Database initialization completed successfully!"
