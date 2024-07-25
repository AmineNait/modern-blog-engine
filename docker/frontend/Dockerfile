# Utiliser l'image officielle Node.js comme image de base
FROM node:18 AS build

# Définir le répertoire de travail dans le conteneur
WORKDIR /app

# Copier les fichiers package.json et package-lock.json pour installer les dépendances
COPY package*.json ./

# Installer les dépendances
RUN npm install

# Copier tous les fichiers de l'application
COPY . .

# Construire l'application Next.js
RUN npm run build

# Utiliser une image officielle Nginx pour servir l'application
FROM nginx:alpine

# Copier les fichiers de build de l'application Next.js dans le dossier de Nginx
COPY --from=build /app/.next /usr/share/nginx/html

# Copier le fichier de configuration Nginx pour Next.js
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Exposer le port 80
EXPOSE 80

# Démarrer Nginx
CMD ["nginx", "-g", "daemon off;"]
