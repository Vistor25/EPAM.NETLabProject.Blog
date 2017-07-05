﻿CREATE TABLE [Role] (
	ID int NOT NULL,
	Name varchar NOT NULL,
  CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User] (
	ID bigint NOT NULL,
	Login varchar(50) NOT NULL,
	Password varchar(65) NOT NULL,
	Nickname varchar(50) NOT NULL,
	RoleID int NOT NULL,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Article] (
	ID bigint NOT NULL,
	Title varchar(500) NOT NULL,
	Content varchar(4000) NOT NULL,
	UserID bigint NOT NULL,
	CreationDate timestamp NOT NULL,
 CONSTRAINT [PK_ARTICLE] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Tag] (
	ID int NOT NULL,
	Name varchar NOT NULL,
  CONSTRAINT [PK_TAG] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ArticleTag] (
	ArticleID bigint NOT NULL,
	TagID int NOT NULL,
  CONSTRAINT [PK_ARTICLETAG] PRIMARY KEY CLUSTERED
  (
  [ArticleID] ,[TagID]
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Comment] (
	ID bigint NOT NULL,
	Text varchar(1000) NOT NULL,
	ArticleID bigint NOT NULL,
	UserID bigint NOT NULL,
	CreationDate timestamp NOT NULL,
  CONSTRAINT [PK_COMMENT] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ArticleLike] (
	ArticleID bigint NOT NULL,
	UserID bigint NOT NULL,
  CONSTRAINT [PK_ARTICLELIKE] PRIMARY KEY CLUSTERED
  (
  [ArticleID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [User] WITH CHECK ADD CONSTRAINT [User_fk0] FOREIGN KEY ([RoleID]) REFERENCES [Role]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [User] CHECK CONSTRAINT [User_fk0]
GO

ALTER TABLE [Article] WITH CHECK ADD CONSTRAINT [Article_fk0] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Article] CHECK CONSTRAINT [Article_fk0]
GO


ALTER TABLE [ArticleTag] WITH CHECK ADD CONSTRAINT [ArticleTag_fk0] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [ArticleTag] CHECK CONSTRAINT [ArticleTag_fk0]
GO
ALTER TABLE [ArticleTag] WITH CHECK ADD CONSTRAINT [ArticleTag_fk1] FOREIGN KEY ([TagID]) REFERENCES [Tag]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [ArticleTag] CHECK CONSTRAINT [ArticleTag_fk1]
GO

ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk0] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk0]
GO
ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk1] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk1]
GO

ALTER TABLE [ArticleLike] WITH CHECK ADD CONSTRAINT [ArticleLike_fk0] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [ArticleLike] CHECK CONSTRAINT [ArticleLike_fk0]
GO
ALTER TABLE [ArticleLike]  ADD CONSTRAINT [ArticleLike_fk1] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [ArticleLike] CHECK CONSTRAINT [ArticleLike_fk1]
GO
select 1;
go
