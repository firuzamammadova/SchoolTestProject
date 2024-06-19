for UI : 

run "npm install" 


run "set NODE_OPTIONS=--openssl-legacy-provider"


run "ng serve"

for API: 

run "dotnet ef migrations add InitialMigration --startup-project C:\Users....\SchoolProject.Api"


run " dotnet ef database update --startup-project C:\...\SchoolProject.Api"
