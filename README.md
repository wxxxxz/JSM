# **JsonStorageManager** is a project which let you easy process json messages, store them under dedicated blob path and list all files stored in blob container.

## SETUP
- Download and configure Microsoft Visual Studio 2022
- Download Microsoft Storage Explorer
- Run Azurite (should be installed with VS, if not download separately)
- Clone project from github repository https://github.com/wxxxxz/JSM
- Run cloned project in VS
- Your set up should be up and running

## USAGE
1. To save json in blob container under path `year/month/day/hour/minute/{guid}.json`
- Open Microsoft Azure Storage Explorer
- Goto Emulator&Attached
- Expand Storage Accounts
- Expand Emulator - DefaultPorts
- Expand Queues
- Create new Queue named `queue`
- Click created queue
- Click + Add
- Insert your JSON
- Confirm with OK
- Goto Blob Containers
- Expand container named `blobContainer`
- Go though the path which represent the current timestamp
- Json was saved there
	
2. To list all the files from blob container
- Open browser
- Paste http://localhost:7062/api/ListBlobs
- All files from blobContainer will be listed