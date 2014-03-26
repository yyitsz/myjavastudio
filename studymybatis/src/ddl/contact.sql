CREATE TABLE  `studymybatis`.`contact` (
  `CONTACT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CONTACT_EMAIL` varchar(255) NOT NULL,
  `CONTACT_NAME` varchar(255) NOT NULL,
  `CONTACT_PHONE` varchar(255) ,
  `BIRTHDAY` date,
  `AGE` int,
  `GENDER` bool,
  VERSION bigint,
  CREATED_AT datetime,
  CREATED_BY varchar(50),
  UPDATED_AT datetime,
  UPDATED_BY varchar(50),
  PRIMARY KEY (`CONTACT_ID`)
)ENGINE=InnoDB;

insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,BIRTHDAY,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact0','(000) 000-0000', 'contact0@loianetest.com','1980-09-09',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact1', '(000) 000-0000', 'contact1@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact2', '(000) 000-0000', 'contact2@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact3', '(000) 000-0000', 'contact3@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact4', '(000) 000-0000', 'contact4@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact5', '(000) 000-0000', 'contact5@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact6', '(000) 000-0000', 'contact6@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact7', '(000) 000-0000', 'contact7@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact8', '(000) 000-0000', 'contact8@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact9', '(000) 000-0000', 'contact9@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact10', '(000) 000-0000', 'contact10@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact11', '(000) 000-0000', 'contact11@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact12', '(000) 000-0000', 'contact12@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact13', '(000) 000-0000', 'contact13@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact14', '(000) 000-0000', 'contact14@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact15', '(000) 000-0000', 'contact15@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact16', '(000) 000-0000', 'contact16@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact17', '(000) 000-0000', 'contact17@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact18', '(000) 000-0000', 'contact18@loianetest.com',0,'system','2010-01-01','system','2010-01-01');
insert into CONTACT (CONTACT_NAME, CONTACT_PHONE, CONTACT_EMAIL,GENDER,VERSION,CREATED_BY,CREATED_AT,UPDATED_BY,UPDATED_AT) values ('Contact19', '(000) 000-0000', 'contact19@loianetest.com',true,0,'system','2010-01-01','system','2010-01-01');

CREATE  TABLE IF NOT EXISTS `studymybatis`.`Author` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `email` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;

CREATE  TABLE IF NOT EXISTS `studymybatis`.`Blog` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `url` VARCHAR(45) NULL ,
  `Author_id` INT NOT NULL ,
  PRIMARY KEY (`id`, `Author_id`) ,
  INDEX `fk_Blog_Author1` (`Author_id` ASC) ,
  CONSTRAINT `fk_Blog_Author1`
    FOREIGN KEY (`Author_id` )
    REFERENCES `studymybatis`.`Author` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE  TABLE IF NOT EXISTS `studymybatis`.`Tag` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `value` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;

CREATE  TABLE IF NOT EXISTS `studymybatis`.`Post` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(45) NULL ,
  `Blog_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_Post_Blog` (`Blog_id` ASC) ,
  CONSTRAINT `fk_Post_Blog`
    FOREIGN KEY (`Blog_id` )
    REFERENCES `studymybatis`.`Blog` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE  TABLE IF NOT EXISTS `studymybatis`.`Post_Tag` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `Post_id` INT NOT NULL ,
  `Tag_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_Post_Tag_Post1` (`Post_id` ASC) ,
  INDEX `fk_Post_Tag_Tag1` (`Tag_id` ASC) ,
  CONSTRAINT `fk_Post_Tag_Post1`
    FOREIGN KEY (`Post_id` )
    REFERENCES `studymybatis`.`Post` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Post_Tag_Tag1`
    FOREIGN KEY (`Tag_id` )
    REFERENCES `studymybatis`.`Tag` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;