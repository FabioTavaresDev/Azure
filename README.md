# Azure.ApimFunctionManagedIdentity

Simples repository to study how to setup an Azure APIM connecting to an Azure Function App via managed identity and vice-versa.



#APIM -> Azure Function

In Short the setup seems to be the following:
    - Function with authentication connected to AAD;
        - this will create an App registration in the AAD where the client Id matters for the APIM.
    - APIM with api, policies and managed identity;
        - The policy should use command "<authentication-managed-identity resource="<Client ID of the app registration created in function app>" />" 
    
Note: If the function needs a key (aka code in query parameter), this should still be provided.

##Notes
- Its unfortunate that you can not do the authentication via RBAC like its possible with Azure KeyVault, Azure Storage Account, etc, where you only need to activate the
managed identity of the source and associated a role permission on the target.
- It should be possible to bring more granularity to the authentication via AAD scopes