# TestStore

You can clone the Repo
If you want to run the app just execute the /publish/SmartHardwareShop.exe
Then navigate to https://localhost:5001/swagger/index.html
You will be able to Add users as you want. This has not been secured for test usage.

You can add a admin user to add products and edit them /api/Authenticate/register-admin
You can add a Customer user  /api/Authenticate/register

Deleting a Product is done by editing and setting the IsDeleted flag to true (This is due to the relational dependancy in the Cart table)
