# Sockets

Desarrollar una aplicación de consola C# que simule el funcionamiento de un chat bidireccional texto.
Para lo anterior, considerar la siguiente lógica de la aplicación:

# Servidor:

Debe ser una aplicación de consola C# que levante un Socket TCP en el puerto 2000.
Al recibir una conexión del Cliente, debe recibir el mensaje enviado y mostrarlo por pantalla.
Una vez mostrado, debe permitir al usuario que se encuentra en el lado del Servidor enviar un mensaje
de vuelta.
La comunicación con el Cliente debe mantenerse abierta hasta que cualquiera de ambos extremos envíe
el mensaje “chao”.
Una vez recibido el mensaje “chao”, el servidor debe quedar a espera de un nuevo Cliente.
Cliente:

Debe solicitar la IP del Servidor y puerto al cual conectarse.
Una vez entregado tiene que interactuar con el Servidor, enviando mensajes y recibiendo respuestas.
La comunicación con el Servidor debe mantenerse abierta hasta que cualquiera de ambos extremos
envíe el mensaje “chao”.
