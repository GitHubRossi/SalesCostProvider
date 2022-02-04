README.md

TaskDescription can be found at SRC\

CostProviderAPI accepts JSON via POST method on: 
https://localhost:44340/CostProviderAPI/CostProductsProvider


See JSON IN/OUT structure

JOB1

JSON-INPUT
{
    "EMargin":true,
    "Products":
    [
        {"Name":"envelopes","Cost":520.00,"STax":true},
        {"Name":"letterhead","Cost":1983.37,"STax":false}
    ]
}
JSON-OUTPUT
{
    "finalCost": 2940.31,
    "productsOut": [
        {
            "name": "envelopes",
            "cost": 556.4
        },
        {
            "name": "letterhead",
            "cost": 1983.37
        }
    ]
}

JOB2

JSON-INPUT
{
    "EMargin":false,
    "Products":
    [
        {"Name":"Tshirt","Cost":294.04,"STax":true}
    ]
}
JSON-OUTPUT
{
    "finalCost": 346.96,
    "productsOut": [
        {
            "name": "Tshirt",
            "cost": 314.62
        }
    ]
}

JOB3

JSON-INPUT
{
    "EMargin":true,
    "Products":
    [
        {"Name":"Frisbees","Cost":19385.38,"STax":false},
        {"Name":"yo-yos","Cost":1829,"STax":false}
    ]
}
JSON-OUTPUT
{
    "finalCost": 24608.68,
    "productsOut": [
        {
            "name": "Frisbees",
            "cost": 19385.38
        },
        {
            "name": "yo-yos",
            "cost": 1829
        }
    ]
}
