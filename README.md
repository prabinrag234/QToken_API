How to Update EF Core Tools
dotnet tool update --global dotnet-ef

How to migrate DB Context 
dotnet ef migrations add InitialCreate

Apply Migration
dotnet ef database update


Password encryption
BCrypt.Net
Why This Is Secure
. Even if someone steals your database, they can't reverse the hashes
· You're not storing sensitive plaintext
. BCrypt adds a salt and is slow by design, making brute-force attacks harder
