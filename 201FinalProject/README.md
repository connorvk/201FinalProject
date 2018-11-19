Test function in backend (Passin.json) Backend will write a Passout.json when read Passin.json

Load Market { "Typename": "LoadMarket" }

Register { "Typename": "Register", "Username": "Vincent", "Userinventory": "XXXXXXXXXXXXXXXXXXXX" }

Login (passout.json will return user's inventory) { "Typename": "Login", "Username": "Vincent" }

Sell { "Typename": "Sell", "Username": "Vincent", "Monstername": "pig", "Ask": "cat", "HP": 100, "Attack": 10 }

Trade { "Typename": "Trade", "Buyer": "Vincent", "Seller": "Baiyu", "Monster": "pig", "Ask": "cat" }

Find (find exact monster) { "Typename": "Find", "Username": "Vincent", "Monstername": "pig", "Ask": "cat", }

Remove (remove monster from market place) { "Typename": "Remove", "Username": "Vincent", "Monstername": "pig", "Ask": "cat", }

Save (Update user's inventory, filename has to be for example "Vincent.json") { "Typename": "Save", "Username": "Vincent", "Userinventory": "kkkkkkkkkk" }