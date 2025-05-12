#!/bin/bash

# Update namespaces in all controllers
find Controllers -name "*.cs" -type f -exec sed -i 's/SIMS_Web\.Data/SIMS.Web.Data/g' {} \;
find Controllers -name "*.cs" -type f -exec sed -i 's/SIMS_Web\.Models/SIMS.Web.Models/g' {} \;
find Controllers -name "*.cs" -type f -exec sed -i 's/SIMS_Web\.Services/SIMS.Web.Services/g' {} \;
find Controllers -name "*.cs" -type f -exec sed -i 's/namespace SIMS_Web\.Controllers/namespace SIMS.Web.Controllers/g' {} \;

# Update namespaces in all models
find Models -name "*.cs" -type f -exec sed -i 's/namespace SIMS_Web\.Models/namespace SIMS.Web.Models/g' {} \;

# Update namespaces in all views
find Views -name "*.cshtml" -type f -exec sed -i 's/SIMS_Web\.Models/SIMS.Web.Models/g' {} \;
find Views -name "*.cshtml" -type f -exec sed -i 's/SIMS_Web\.Controllers/SIMS.Web.Controllers/g' {} \;

echo "Namespace updates completed!"
