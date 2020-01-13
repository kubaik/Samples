#FROM openjdk:13
FROM gradle:jdk13 as builder
COPY . /app
WORKDIR /app
RUN gradle build
RUN ls /app/build/

#FROM openjdk:10-jre-slim
#EXPOSE 8080
#COPY --from=builder /home/gradle/src/easytext.web/build/distributions/easytext.web.tar /app/
#WORKDIR /app
#RUN tar -xvf easytext.web.tar
#WORKDIR /app/easytext.web
#CMD bin/easytext.web


#FROM openjdk:13
#CMD ["gradle", "gradlew"]
#RUN javac Main.java
#CMD ["java", "Main"]

#Start a Java instance in your app
#$ docker build -t my-java-app .
#$ docker run -it --rm --name my-running-app my-java-app

#Compile your app inside the Docker container
#docker run --rm -v "$PWD":/repo -w /repo/src/main/java openjdk:13 javac Main.java