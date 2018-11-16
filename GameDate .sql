DROP DATABASE IF EXISTS Info;
CREATE DATABASE Info;
USE Info;

CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY key,
	Username VARCHAR(255),
	UserPassword VARCHAR(255)
);

CREATE TABLE Inventory(
	MonsterID INT(11) AUTO_INCREMENT PRIMARY key,
	Username VARCHAR(255),
    Monstername VARCHAR(255),
	HP INT(11),
	Attack INT(11)
);

CREATE TABLE Market(
    Username VARCHAR(255),
	Monstername VARCHAR(255),
    Ask VARCHAR(255),
	HP INT(11),
	Attack INT(11)
);

