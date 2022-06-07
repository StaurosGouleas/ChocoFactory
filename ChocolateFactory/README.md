----------------------------------------------------------------------------------------------------------------------------------------

![Logo](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/choco.png "Logo")


----------------------------------------------------------------------------------------------------------------------------------------

# 🏭CHOCOFACTORY #


<details><summary><strong>Description(GR)</strong></summary>
<p>
    <ol><li>Αρχικά η επιχείρηση θα έχει 1 Εργοστάσιο με δυνατότητα επέκτασης</li></ul>
    <li> Επίσης θα έχει και 1 κατάστημα πώλησης των προϊόντων με δυνατότητα επέκτασης</li>
    <li> Το εργοστάσιο θα παράγει διάφορα είδη σοκολάτας </li>
    <li> Το εργοστάσιο θα προμηθεύεται την πρώτη ύλη κάθε χρόνο με συμβόλαιο από συγκεκριμένο προμηθευτή. Σε Περίπτωση που η πρώτη ύλη πέσει στο 10 % τότε θα γίνεται νέα συμπληρωματική παραγγελία από τον ίδιο Προμηθευτή.</li>
    <li> Θα δεχόμαστε 3 προσφορές από Προμηθευτές οι οποίες θα αφορούν ποσότητα, τιμή ανά κιλό, ποιότητα (δείκτης όσο μεγαλύτερη η ποιότητα τόσο μεγαλύτερη η τιμή)</li>
    <li> Η επιχείρηση θα διαθέτει εργαζόμενους στο εργοστάσιο και στο κατάστημα πώλησης (Ignore for now)</li>
    <li> Τα είδη σοκολάτας που θα παράγει θα είναι λευκή, μαύρη, γάλακτος. Η γάλακτος χωρίζεται σε επιπλέον κατηγορίες: σκέτη, αμυγδάλου, φουντούκι. Κάθε είδος θα έχει διαφορετική τιμή πώλησης. Το κύριο προϊόν παραγωγής θα είναι η μαύρη σοκολάτα.</li>
    <li> Βασικός στόχος της πρώτης έκδοσης του ΣΥΣΤΗΜΑΤΟΣ είναι να μπορεί να επιλέξει προμηθευτή,  να παράγει σοκολάτες και να πουλάει από το κατάστημα.</li>
    <li> Το κατάστημα που θα πουλάει τις σοκολάτες έχει πολιτική έκπτωσης κάθε δεύτερη Τρίτη του μήνα να εφαρμόζει 20 % έκπτωση στα προϊόντα του. </li>
    <li> Η πρώτη ύλη από τους προμηθευτές θα παραλαμβάνεται σε κιλά. Στο τέλος του έτους ότι περισσέψει (εάν περισσέψει) θα αφοσιώνεται σε πειραματισμό για νέα προϊόντα. </li>
    <li> Τα Προϊόντα που θα παράγονται για πειραματισμό θα δίνονται ως δώρο σε πελάτες που υλοποιούν αγορές πάνω από 30 ευρώ(1 προϊόν ανά 30 ευρώ). </li>
    <li> Εάν τα κέρδη της επιχείρησης στο τέλος του χρόνου φτάσουν σε ένα συγκεκριμένο ποσοστό θα δημιουργείται αυτόματα νέο κατάστημα πώλησης προϊόντων. Το ποσοστό θα καθορίζεται από τον πρόεδρο της εταιρίας. </li>
    <li> Η Παραγωγή θα είναι ημερήσια σταθερή 500 σοκολάτες. Το 50 % της σοκολάτας που θα παράγεται αρχικά θα πηγαίνει απευθείας στο κατάστημα. Το υπόλοιπο θα παραμένει σε αποθήκη που ανήκει στο εργοστάσιο. Όταν το ποσοστό στο κατάστημα πέφτει στο 25% τότε θα ανεφοδιάζεται πάλι από την αποθήκη στο τέλος της κάθε μέρας ώστε να έχει πάντα το 50% της παραγωγής. </li>
    <li> Κάθε νέο κατάστημα πώλησης θα διαθέτει τοποθεσία, δικούς του υπαλλήλους και θα μπορεί να αποδίδει ξεχωριστά τα κέρδη του προς την επιχείρηση. </li>
    <li> Στο τέλος κάθε ημέρας το κάθε κατάστημα θα αποδίδει αναφορά πόσο προϊόντα πουλήθηκαν από κάθε είδος καθώς και το υπόλοιπό τους. </li>
    </p>
</details>


------------------------------------------------------------------------------------------------------------------------------------------------------

📋Table of contents
=================

<!--ts-->


   * [Domain](#domain)
      * [IDeparment](#ideparment)
      * [ICompany](#icompany)
      * [IFactory](#ifactory)
      * [Company](#company)
      * [Accounting](#accounting)
      * [Production](#production)
      * [Warehouse](#warehouse)
      * [Factory](#factory)
      * [Shop](#shop)
   * [Human](#human)
      * [IHuman](#ihuman)
      * [IEmployee](#%EF%B8%8Fiemployee)
      * [Employee](#employee)
      * [Supplier](#supplier)
   * [Products](#products)
      * [IProduct](#iproduct)
   * [Offer-Order](#offer-order)
   * [Policy](#policy)
      * [CompanyPolicy](#companypolicy)
      * [PricePolicy](#pricepolicy)
      * [ProductionPolicy](#productionpolicy)
      * [FactoryPolicy](#factorypolicy)
      * [ShopPolicy](#shoppolicy)
   * [Services](#services)
   * [Business Logic Diagramm](#business-logic-diagram)
   * [Tasks](%EF%B8%8Ftasks)
   * [Technologies](#technologies)
   * [Team](#team)
   
   
<!--te-->
                                                                                                               

![factorydiagram](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/ChocoFactoryDiagram.drawio.png "First Approach Diagram")
------------------------------------------------------------------------------------------------------------------------------

# /Domain/ #

## IDeparment ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get  |
| string         | Description      | get|

##### [Back to >Top<](#chocofactory) #####

## ICompany ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| decimal            | Capital      | get |
| decimal         | Revenue       | get, set    |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _DailyActions(DateTime currentDate)_ | Set the daily Action of Company |
| _YearlyActions()_ | Set the yearly Action of Company |

##### [Back to >Top<](#chocofactory) #####

## IFactory ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int             | ID       | get |
| string          | City        | get|
| string          | Address         | get|
| double           | TotalProducts          | get|
| double           | TotalEmployees          | get|


##### [Back to >Top<](#chocofactory) #####

## 🏢Company ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| decimal | Capital      | get; private set;  |
| decimal  | Revenue       | get; set;  |
| List of Factory | Employees        | get; set;  |
| List of Shop    | Shops | get; set;   |
| List of Employee      | Employees     | get; set;|
| CompanyPolicy     | CompanyPolicy     | get; set; |
| bool     | RevenueGoalAchieved    | get; set; |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _DailyActions(DateTime currentDate)_ | Set the daily Action of Company |
| _YearlyActions()_ | Set the yearly Action of Company |


##### [Back to >Top<](#chocofactory) #####

## 🧮Accounting ##
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int | DepartmentID      | get; set;  |
| Factory  | Factory       | get; set;  |
| List of Employee | Employees        | get; set;  |
| List of Offer    | AvailableOffers  | get; set;   |
| offer      | BestOffer     | ---- |
| Supplier     | LastSupplier     | get; set; |
| Order     | LastOrder     | get; set; |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _ReceiveOffers()_ | Add a new offer in the list of AvailableOffers |
| _Order SendOrder(Offer offer)_ | Send Offer to Accounting Deparment |
| _double OfferValue(Offer offer)_ | Calcualtes the value of offer |

##### [Back to >Top<](#chocofactory) #####

## 🏦Production
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Factory            | Factory     | get, set   |
| ProductionPolicy             | ProductionPolicy      | get, set   |
| string               | Description        | get, set   |


| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _IProduct CreateProduct(string productName)_ | Choose what kind of Chocolate we want to create |


##### [Back to >Top<](#chocofactory) #####

## 📦Warehouse

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory) #####

## 🏫Factory

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Warehouse          | Warehouse     | get, set   |
| Production         | Production      | get, set    |
| Company            | Company        | get, set    |
| Accounting            | Accounting        | get, set    |
| List of Shop           | Shops       | get, set    |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _OpeningActions()_ | Set the opening actions of factory|
| _DailyActions(DateTime currentDate)_ | Set the daily actions of factory|
| _YearlyActions()_ | Set the yearly actions of factory |


##### [Back to >Top<](#chocofactory) #####

## 🏪Shop ##
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Company            | Company     | get, set   |
| List of Product        | Products      | get, set    |
| List of Employee            | Employees        | get, set    |
| Dictionary string, int            | DailyProductsSold        | {the products for sale}etc "WhiteChocolate"|
| string            | Location        | get, set    |
| decimal            | DailyEarnings        | get, set    |
   

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _SellProduct(string productName)_ | Sell Product, add the price Of Product in Daily, increase DailyProductsSold|
| _ServeCustomer(List string productsToSell)_ | Get the order of Customer and check if the products have value more than 30 euro|
| _DailyActions(DateTime date)_ | What do extactly every day the object Shop |
| _DailyReport()_ | Daily report of sales and earnings|
| _SendDailyEarnings()_ |  The Shop send the daily earnings to object Company|
| _IsProductQuantityLow()_ | Check the Avalaible Quantity of Products of Shop|
| _RefillProducts()_ | Refill Products,if the IsProductQuantityLow() is true |
| _ReceiveProduct()_ | Receive Product from Warehouse |
| _RemoveExpiredProducts(DateTime currentDate)_ | Check if the Products have passed the ExpiredDate and it throws away.|


##### [Back to >Top<](#chocofactory) #####

# /Human/ #

## 🧑IHuman ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |

## 👷‍♂️IEmployee ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int             | EmployeeID      | get  |
| string         | DeparmentId       | get  |
| string            | ManagerId      | get  |
| decimal        | Salary       | get, set    |
| string         | EmailAddres       | get, set    |


## 👨‍🏭Employee ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int             | EmployeeID      | get  |
| string         | DeparmentId       | get  |
| string            | ManagerId      | get  |
| decimal        | Salary       | get, set    |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | EmailAddres       | get, set    |
| double          | Phone        | get, set    |


## 👴Supplier ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| double         | PhoneNumber       | get, set    |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _SendSupplies(Order order)_| Send Supplies from Supplier to Production|
| _endOffer(decimal pricePerKilo, Quality quality, int suppliesKilos)_ | Send Offer to Accounting Deparment |

##### [Back to >Top<](#chocofactory) #####

# 🍫Products #

## IProduct ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string         | Description       | get, set    |
| DateTime          | ProductionDate        | get, set    |
| DateTime          | ExpirationDate         | get, set    |
| decimal             | Price         | get, set    |

### IChocolate ### 
- DarkChocolate
- WhiteChocolate
- ExperimentalProduct

### IMilkChocolate ###
- PlainMilkChocolate
- AlmondMilkChocolate
- HazelnutMilkChocolate

# Offer-Order #

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| decimal            | PricePerKilo      | get, set   |
| Quality          | Quality        | get, set    |
| int           | Quantity         | get, set    |
| decimal           | TotalCost          | get, set    |
| Supplier              | Supplier          | get, set    |
| _Factory_             | Factory          | get, set    | only for __Order__



##### [Back to >Top<](#chocofactory) #####

## 👮Policy ##

### CompanyPolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |                                    
| FactoryPolicy             | Factory     | get, set   |
| ProductionPolicy         | Production      | get, set    |
| PricePolicy             | Pricing        | get, set    |
| ShopPolicy             | Shop        | get, set    |


### FactoryPolicy ####

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |                                    
| int            | DailyProducts     | get, set   |
| double        | LowSuppliesThresholdPercent      | get, set    |
| double            | MinimumRevenueToInvest        | get, set    |
| double            | RevenueYearlyGoal        | get, set    |
| int            | NumberOfOffers        | get, set    |

### ProductionPolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  | 
| double             | BlackChocolatePercent     | get, set   |
| double        | WhiteChocolatePercent      | get, set    |
| double            | MilkChocolatePercent        | get, set    |
| double            | AlmondMilkChocolatePercent        | get, set    |
| double            | HazelnutMilkChocolatePercent        | get, set    |
| int            | BlackChocolateSupplies     | get, set   |
| int        | WhiteChocolateSupplies      | get, set    |
| int            | AlmondMilkChocolateSupplies        | get, set    |
| int            | HazelnutMilkChocolateSupplies        | get, set    |
| int            | ExperimentalChocolateSupplies        | get, set    |

### ShopPolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |    
| double            | ProductsToShopPercent        | get, set    |
| double            | ShopRestockPercent        | get, set    |
| int            | ShopStockSize        | get, set    |
| int            | ShopRestockThreshold        | get, set    |
| double            | ShopDiscount        | get, set    |
| DayOfWeek      | DiscountDay        | get, set    |
| int      | DiscountDayOccurence        | get, set    |
| decimal      | GiftMinimumPrice        | get, set    |

### PricePolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |                                
| decimal            | BlackChocolatePrice        | get, set    |
| decimal           | WhiteChocolatePrice        | get, set    |
| decimal      | MilkChocolatePrice        | get, set    |
| decimal      | AlmondMilkChocolatePrice        | get, set    |
| decimal      | HazelnutMilkChocolatePrice        | get, set    |



## 🔨Services ##

| Title         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| _ICustomerService_| Interface for CustomerService |
| _ISupplierService_ | Interface for SupplierService|
| _CustomerService_|  |
| _SupplierService_ | |
| _RandomGenerator_| Create random data for different processes|
| _ImportJsonHelper_ | Import data from json to list of object|


## 📈Business Logic Diagram ##
------------------------------------------------------------------------------------------

![Business Logic](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/MicrosoftTeams-image%20(1).png)

------------------------------------------------------------------------------------------


## 🎖️Tasks ##

### Project status ###
- [x] Analysis
- [x] Design
- [x] Development
- [x] Unit testing
- [x] Mockup Data  


## 🖥️Technologies + recourses ##

### Technologies ###
- Programming Language C#
- Framework .NET 4.7.3
- Console Application

### Recourses ###
- [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Official documentation](https://docs.microsoft.com/en-us/)
- [Factory-Design-Pattern](https://dotnettutorials.net/lesson/factory-design-pattern-csharp/)


##### [Back to >Top<](#chocofactory) ####

------------------------------------------------------------------------------------------
## 🤝Team ##
- [👨Ioannins T.](https://github.com/ioannis-thyris)
- [🧑Dimitris B.](https://github.com/GitEmm)
- [👨Dimitris Z](https://github.com/zafeirisdimi)
- [🧔Stavros G.](https://www.github.com/StaurosGouleas)

