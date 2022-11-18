FROM ubuntu:latest

RUN apt-get -y update
RUN apt-get -y upgrade
RUN apt-get install -y build-essential
RUN apt install -y python3

RUN apt install -y iputils-ping
RUN apt install -y ncat
RUN apt install -y dos2unix
RUN apt install -y vim
RUN apt install -y net-tools

#RUN apt install -y golang-go

ENV APP_PATH=/use/src/gopher
RUN mkdir -p $APP_PATH
RUN cd $APP_PATH

WORKDIR $APP_PATH
COPY / $APP_PATH
RUN chmod -R 777 $APP_PATH
RUN dos2unix **


CMD ["./gopher.py"]
