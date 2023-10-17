This did not work out the way I wanted...

This app was supposed to consist of 3 parts: the NeoClient for people that Morpheus can contact and the Morpheus Client & Server (located next to each other).
It made sense to separate the GUI parts from the business logic of the server.
Morpheus planned to run the code with a *.bat script that would create a secure.txt file with a random string and run the server and his own client.

His client is able to send a special message to auth as the real Morpheus because only it can possibly know the contents of secure.txt.

There were a few issues with my approach too. I am personally unaware of how to handle "Keep Alive" TCP/IP connections. The current approach uses colons as message delimeters, whereas it would have made more sense to use Websockets.
Not to mention the lack of SSL connection encryption...

I've decided to include the images of the UI for you to see what I managed to make.