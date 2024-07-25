# Utiliser l'image officielle Node.js comme image de base
FROM node:18 AS build
WORKDIR /app
COPY ../frontend/package*.json ./
RUN npm install
COPY ../frontend ./
RUN npm run build

# Utiliser l'image officielle Nginx pour servir l'application
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
