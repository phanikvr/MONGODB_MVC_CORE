// db = connect("mongodb://localhost:27017/myNewDB");
// db = connect("mongodb://127.0.0.1:27017/myNewDB");

// we can execute javascript file directly in MongoDB to add data. To insert pre-existing data or for copy/paste sake ;)

//db.blogColNested.drop(); // this deletes the collection. using this to freshly create data and test it. if you want u can uncomment it
db.blogColNested.insert(
{
    "BlogUser": { "UserId": "venkat", "Age": 30, "DisplayName": "Hello Venakt!" },
    "Title": "MongoDB Overview",
    "Description": "MongoDB is no sql database",
    "By": "tutorials point",
    "Url": "http://www.tutorialspoint.com",
    "Tags": ["mongodb", "database", "NoSQL"],
    "Likes": 100,
    "Comments": [
      {
          "User": "user1",
          "Message": "My first comment",
          "DateCreated": new Date(2011, 1, 20, 2, 15),
          "Like": 0
      },
      {
          "User": "user2",
          "Message": "My second comments",
          "DateCreated": new Date(2011, 1, 25, 7, 45),
          "Like": 5
      }
    ]
});
/*
db.newCol.createIndex({user":1});
*/



 db.inventory.insert( [
 { "item": "canvas", 		"qty": 100,	"size": { "h": 28, 	"w": 35.5, 	"uom": "cm" }, "status": "A" },
 { "item": "journal", 		"qty": 25, 	"size": { "h": 14, 	"w": 21, 	"uom": "cm" }, "status": "A" },
 { "item": "mat", 			"qty": 85, 	"size": { "h": 27.9,"w": 35.5, 	"uom": "cm" }, "status": "A" },
 { "item": "mousepad", 	"qty": 25, 	"size": { "h": 19, 	"w": 22.85, "uom": "cm" }, "status": "P" },
 { "item": "notebook", 	"qty": 50, 	"size": { "h": 8.5, "w": 11, 	"uom": "in" }, "status": "P" },
 { "item": "paper", 		"qty": 100, "size": { "h": 8.5, "w": 11, 	"uom": "in" }, "status": "D" },
 { "item": "planner", 		"qty": 75, 	"size": { "h": 22, 	"w": 30, 	"uom": "cm" }, "status": "D" },
 { "item": "postcard", 	"qty": 45, 	"size": { "h": 10, 	"w": 15.25, "uom": "cm" }, "status": "A" },
 { "item": "sketchbook", 	"qty": 80, 	"size": { "h": 14, 	"w": 21, 	"uom": "cm" }, "status": "A" },
 { "item": "sketch pad", 	"qty": 95, 	"size": { "h": 21, 	"w": 30.5, 	"uom": "cm" }, "status": "A" }
 ]);

/*
// when u r posting data to the API url for creating a new blog, use the folloing format: because for the sake of learning, i've masked the document names from DB to API
{
	"user": {"userId":"venkat", "age":30, "displayName":"Hello Venakt!"},
	"title": "MongoDB Overview",    
	"description": "MongoDB is no sql database",   
	"by": "tutorials point",   
	"url": "http://www.tutorialspoint.com",
   	"tags": ["mongodb", "database", "NoSQL"],   
	"likes": 100,
                "comments": [
{
        "user":"user1",
         "message": "My first comment",
         "dateCreated": "01/02/2017",
         "like": 0 
      }
]
}
*/
