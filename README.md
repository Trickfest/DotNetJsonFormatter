# DotNetJsonFormatter

Format json into ascii tables, csv, etc.

For more information, see ExampleUsage sample program.

    *********** JSON ***********
    [{\"person id\":1,\"name\":\"O\\\"Miley\",\"created date\":\"12/9/2017 8:01:52 PM\"},...]
    *********** ASCII TABLE **********
    Person Id    Name        Created Date
    -----------  ----------  ----------------------
    1            O"Miley     12/9/2017 8:01:52 PM
    2            Sally       12/9/2017 8:01:52 PM
    3            Jackie      12/9/2017 8:01:52 PM
    4            Freddie     12/9/2017 8:01:52 PM
    5            McMaster    12/9/2017 8:01:52 PM
    *********** CSV **********
    Person Id,Name,Created Date
    1,"O""Miley",12/9/2017 8:01:52 PM
    2,Sally,12/9/2017 8:01:52 PM
    3,Jackie,12/9/2017 8:01:52 PM
    4,Freddie,12/9/2017 8:01:52 PM
    5,McMaster,12/9/2017 8:01:52 PM
