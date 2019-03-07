# Samples


Each of sample is separated as two solution for easy debugging. 

* **Chat Server/Client** - A simple chatting server/client sample. 
* **Simple Server/Client** - A sample uses different language for each side of server and client: C# for the server and Cpp for the client.


## TroubleShooting

* Be carefult about the file format:
  * Select project > Right click > Properties > *Buld* panel
    * Specify *Platform target* as appropriate one. e.g. if *enet* was built as *x86*, all others also has to be specified as the same target.
* Don't miss call ***Library.Initialize()*** to initialize *enet* library before calling any *enet* function. 