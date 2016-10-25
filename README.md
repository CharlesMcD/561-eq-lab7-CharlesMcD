# Lab7
- Travail individuel
- Compte pour 1 point
- Remettre avant le début du prochain cours

## Installation
- Copier tout le contenu du lab 6 dans ce repository (**sans le dossier caché .git**)
- Faire un commit et synchroniser

## Objectif
- Avoir deux images: 
  - L'une nommée **webapp:test** qui exécute les tests de l'application web et, dans le cas d'un succès, publie le site web.
  - L'autre nommée **webapp:release** qui exécute l'application web à partir des fichiers publiés. 
- Copier (manuellement, en ligne de commande) l'image webapp:release sur docker hub

## Étapes
### Structure du repository et nommage
- Renommer le fichier **Dockerfile** en **test**.
- Renommer le dossier **docker** en **dockerfile**. Ce dossier va contenir tous les *dockerfiles*.
- À la racine du repository, créer un dossier **scripts** et y déplacer les scripts existants.

### Création de l'image d'exécution et de publication
- Le nom du dockerfile est **test** (à mettre dans le dossier *dockerfile*)
- Le nom du script est **testAndPublish.sh** (à mettre dans le dossier *scripts*)
- L'image doit exécuter les tests de l'application web et, dans le cas d'un succès, publier le site web dans le dossier */root/publish* du conteneur.
- Pour construire l'image: **docker build -t webapp:test -f ./dockerfile/test .**
- Pour exécuter le conteneur: **docker run -it --rm -v $PWD/publish:/root/publish -v $PWD/packages:/root/.nuget/packages webapp:test**
   - L'option *-v $PWD/publish:/root/publish*, nous permet de conserver les fichiers publiés dans le conteneur (*/root/publish*) en local (*$PWD/publish*) dans le but de les copier dans la prochaine image.
  
### Création de l'image d'exécution du site web 
- Le nom du dockerfile est **release** (à mettre dans le dossier *dockerfile*)
- Ce dockerfile n'a pas besoin de script.
- L'image doit être basée sur **microsoft/dotnet:latest** et non **ymazieres/dotnet:compile**. Cette dernière étant utile pour la compilation, elle n'est pas nécessaire pour l'exécution des fichiers publiés.
- Pour construire l'image: ** docker build -t webapp:release -f ./dockerfile/release .**
- Pour tester l'image *release* en local, exécuter le conteneur: **docker run -it --rm -p 8080:5000 webapp:release**

### Copier (manuellement, en ligne de commande) l'image webapp:release sur docker hub
- Une image sur docker hub doit avoir le format suiavnt: ORGANISATION/NOM_IMAGE:TAG. Exemples: 
  - ymazieres/dotnet:compile
  - ymazieres/wepapp:latest
  - microsoft/dotnet:latest
  - centos/wordpress:latest
- Pour *pusher* une image sur docker hub, on doit taguer l'image dans le bon format, se connecter et l'envoyer. Exemple pour l'image **webapp:release** :
```
   docker tag webapp:release ymazieres/webapp:latest
   docker login -u=ymazieres -p=monmotdepasse
   docker push ymazieres/webapp:latest
```
- Faire un push de l'image **webapp:release** dans votre compte docker hub (**VOTRE_NOM_UTILISATEUR_DOCKER_HUB/webapp:latest**)
