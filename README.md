
# asp.net core mvc with api and identity server

## Overview
  This repository contains a sample code where an mvc app is authenticated by an open id connect provider which happens to be the identity server project in this solution. The mvc app can access the secured api included in the project using JWT that it receives from the identity server.

**Note**: The codes in this solution is for demonstration purposes only. My goal is to give you an idea on how you can integrate the pieces I've mentioned above. When you go into production, you shouldn't hardcode your settings directly into the app, usually, it's retrieved during runtime which can then used to configure your identity server.

## Running the solution
1. Open using visual studio.
2. Build the solution.
3. Set all projects as multiple startup projects.
4. Run the app.

## Testing
1. Open the mvc app and visit the **/weather** route which is a protected route.
2. If you're not yet authenticated, you'll be redirected to the identity server to enter your credentials.
3. Enter the username "bob" and password "bob" as well.
4. After authentication, you'll see the weather cards which the mvc app retrieved from the secured api route in the solution.

## Technologies used
- asp.net core 3
- Identity server 4