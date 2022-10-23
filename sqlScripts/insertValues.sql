insert into [User] values('user1','pass')
insert into [User] values('user2','pass')


insert into Post values('user1',GETDATE(),'Test Description','Test Title','imgLocation1',80.2000,-14.2000) 
insert into Post values('user2',GETDATE(),'Test Description2','Test Title2','imgLocation2',10.2000,-24.2000) 
insert into Post values('user2',GETDATE(),'Test Description3','Test Title3','imgLocation3',10.225,-24.2203) 


select * from Post