CREATE TABLE [Role] (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Name varchar(100) NOT NULL

)
GO
CREATE TABLE [User] (
	ID bigint  IDENTITY(1,1) PRIMARY KEY,
	Login varchar(50) NOT NULL,
	Password varchar(65) NOT NULL,
	Nickname varchar(50) NOT NULL
)
CREATE TABLE [Membership] (
	UserID bigint NOT NULL,
	RoleID bigint NOT NULL,
	constraint pk_Membership primary key(UserID ,RoleID)

)
GO
CREATE TABLE [Article] (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Title varchar(500) NOT NULL,
	Content varchar(4000) NOT NULL,
	UserID bigint NOT NULL,
	CreationDate datetime NOT NULL

)
GO
CREATE TABLE [Tag] (
	ID bigint  IDENTITY(1,1) PRIMARY KEY,
	Name varchar(100) NOT NULL

)
GO
CREATE TABLE [ArticleTag] (
	ArticleID bigint NOT NULL,
	TagID bigint NOT NULL,
	constraint pk_ArticleTag primary key(ArticleID  ,TagID)

)
GO

CREATE TABLE [Comment] (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Text varchar(1000) NOT NULL,
	ArticleID bigint NOT NULL,
	UserID bigint NOT NULL,
	CreationDate datetime NOT NULL

)
GO

CREATE TABLE [ArticleLike] (
	ArticleID bigint NOT NULL,
	UserID bigint NOT NULL,
	constraint pk_ArticleLike primary key(ArticleID ,UserID )

)
GO

ALTER TABLE [Membership] WITH CHECK ADD CONSTRAINT [Membership_fk0] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ALTER TABLE [Membership] CHECK CONSTRAINT [Membership_fk0]
GO
ALTER TABLE [Membership] WITH CHECK ADD CONSTRAINT [Membership_fk1] FOREIGN KEY ([RoleID]) REFERENCES [Role]([ID])
ALTER TABLE [Membership] CHECK CONSTRAINT [Membership_fk1]
GO

ALTER TABLE [Article] WITH CHECK ADD CONSTRAINT [Article_fk0] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ALTER TABLE [Article] CHECK CONSTRAINT [Article_fk0]
GO

ALTER TABLE [ArticleTag] WITH CHECK ADD CONSTRAINT [ArticleTag_fk0] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ALTER TABLE [ArticleTag] CHECK CONSTRAINT [ArticleTag_fk0]
GO
ALTER TABLE [ArticleTag] WITH CHECK ADD CONSTRAINT [ArticleTag_fk1] FOREIGN KEY ([TagID]) REFERENCES [Tag]([ID])
ALTER TABLE [ArticleTag] CHECK CONSTRAINT [ArticleTag_fk1]
GO

ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk0] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk0]
GO
ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk1] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk1]
GO

ALTER TABLE [ArticleLike] WITH CHECK ADD CONSTRAINT [ArticleLike_fk0] FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
ALTER TABLE [ArticleLike] CHECK CONSTRAINT [ArticleLike_fk0]
GO
ALTER TABLE [ArticleLike] WITH CHECK ADD CONSTRAINT [ArticleLike_fk1] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID])
ALTER TABLE [ArticleLike] CHECK CONSTRAINT [ArticleLike_fk1]
GO