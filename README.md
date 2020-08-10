
# asp.net core mvc with api and identity server

  This repository contains a sample code where an mvc app is authenticated by an open id connect provider which happens to be the identity server project in this solution. The mvc app can access the secured api included in the project using JWT that it receives from the identity server.

**Note**: The codes in this solution is for demonstration purposes only. My goal is to give you an idea on how you can integrate the pieces I've mentioned above. When you go into production, you shouldn't hardcode your settings directly into the app, usually, it's retrieved during runtime which can then used to configure your identity server.

## Technologies used
- asp.net core 3
- Identity server 4