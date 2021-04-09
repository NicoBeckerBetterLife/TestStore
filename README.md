# TestStore

You can clone the Repo
If you want to run the app just execute the /publish/SmartHardwareShop.exe
Then navigate to https://localhost:5001/swagger/index.html

You will be able to Add users as you want. This has not been secured for test usage.

You can add a Admin user to add products and edit them /api/Authenticate/register-admin

You can add a Customer user  /api/Authenticate/register

Deleting a Product is done by editing and setting the IsDeleted flag to true (This is due to the relational dependancy in the Cart table)

The app is using a SQL LocalDB and can be accessed using SSMS. (Server "(LocalDb)\MSSQLLocalDB")
You may need to have .Net installed for this to run. I am not sure as i don't have access to a PC without that. 
Also due to the DB this will need to be ran on a Windows Machine.

Thx
