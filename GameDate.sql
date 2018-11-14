CREATE DATABASE Info;
USE Info;
CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY key,
	Username VARCHAR(255),
    UserPassword VARCHAR(255)
);

CREATE TABLE Market(
	MonsterID INT(11) AUTO_INCREMENT PRIMARY key,
    MonsterType VARCHAR(255),
	MonsterName VARCHAR(255),
    HP INT(11),
    Attack INT(11),
    SaveID INT (11),
    Cost VARCHAR(255)
);

CREATE TABLE Inventory(
	SaveID INT(11),
    Username VARCHAR(255),
	MonterType VARCHAR(255),
    Monstername VARCHAR(255),
    CurrentHP INT(11),
    Attack INT(11)
);