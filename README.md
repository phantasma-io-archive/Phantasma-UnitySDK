# Phantasma Unity SDK
This is the UPM Lib Unity SDK for Phantasma to interact with the Phantasma Blockchain.

# Import it to your project.
Inside Unity, go to `Window > Package Manager`. 
Then on the Top left corner press the `+` button, add package from git URL
This is the git URL to import the package `https://github.com/phantasma-io/Phantasma-UnitySDK.git`

# How to connect to the Wallet via the SDK
Setup your scene, Add the PhantasmaLinkClient prefab to your scene.
* If you're developing in a local node, change the "Nexus" to `localnet`
* If you're deploying it to the testnet, change the "Nexus" to `testnet`
* If you're deploying it to the mainnet, change the "Nexus" to `mainnet`
* Change the DappID to your Dapp "contract name", this is what will appear when a user log's in to your Dapp.
* Recommended version is 2
* Wallet Endpoint default:`localhost:7090` (Don't change it)
* Regarding the Platform and Signature, For `Phantasma` -> `ED25519`, for `Ethereum` -> `ECDSA`

# How to connect to the Wallet via the SDK (Android)
The same thing as the normal method, but you need to added the PhantasmaLinkClientPlugin Prefab to your Scene.

And that's it, just build for Android, you're done!

# Any further questions
- Contact Phantasma Force Team