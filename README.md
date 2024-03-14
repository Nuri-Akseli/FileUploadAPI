[FileUploadAPI.postman_collection.json](https://github.com/Nuri-Akseli/FileUploadAPI/files/14600713/FileUploadAPI.postman_collection.json)# Description
This is a simple .Net Core Web API project that hold files and according to request file can be uploaded or existed file can be deleted
# Database
A database is used to determine whether incoming requests are from registered users. In addition, it is aimed to keep the server cleaner by aiming for each user to have a unique directory.![fileUploadAPIDatabase](https://github.com/Nuri-Akseli/FileUploadAPI/assets/89780770/4785ebf3-3ef5-43cf-a826-f20faa28495c)

# Requests
1-) /api/File/Post
This request used for Upload File to Server
## Parameters
- Username
- Password
- Folder
- File
## Response
{
    "path": "File Path",
    "name": "File Name with Extension"
}

2-) /api/File/Delete
This Request used for delete existed file in server
## Parameters
- Username
- Password
- Path
- name
## Response
Only return httpcode 200 if request is successful

# Postman Examples
![Post](https://github.com/Nuri-Akseli/FileUploadAPI/assets/89780770/3a590d43-de9f-4803-9cd0-543d95924e16)
![Delete](https://github.com/Nuri-Akseli/FileUploadAPI/assets/89780770/d751fa26-6b17-4d36-8130-c40f79b60024)


