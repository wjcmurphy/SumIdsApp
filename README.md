#SumIdsApp

Quick implemenation of app that will: "Given a JSON string which describes a menu, calculate the SUM of the IDs of all "items", as long as a "label" exists for that item."
The command line app reads in a file path that must contain a json string that matches the menu described below.

##Sample Json string

```javascript

[{
        "menu": {
            "header": "menu",
            "items": [{
                "id": 8,
                "label": "Some Label"
            }]
        }
    },
    {
        "menu": {
            "header": "menu",
            "items": [

                {

                    "id": 23,

                    "label": "Some more Labels"

                },
                {

                    "id": 19,

                    "label": "Some other label"

                },

                {

                    "id": 45

                }
            ]
        }
    }
]

```

- The above should return:
- 8
- 42

##Installation
- In order to begin working on or using this application you will need to first install Visual Studio. 
- Once you have installed visual studio and cloned the repository you should be able to navigate to the SumIdsApp project and then to Program.cs.
- Once there clicking "Play" in your Visual Studio editor should start the application.


###Tips
- If you enter a path that does not exist or contains data that is not of the form described above the app will prompt you to try again. Typing 'Y' will allow you to continue and anything else will exit the application.

