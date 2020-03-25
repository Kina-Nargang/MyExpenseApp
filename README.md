# MyExpenseApp
Youtube link : https://youtu.be/UubEL9Z-Fxc

<Summary>
 
 
This mobile is using xamarin and C#, emulating on Android. It allows users to enter expense and budget, calculates the balance for users.


<Design>
 
 
This mobile app has 4 pages: Home page, expense entry page, budget page and expense list page.
 
 
  * Home page : 
      - Navigation: 
          1. +Expense button : navigate to Enpense Entry page
          2. +Budge button : navigate to Budge Entry page
          3. +Add button : navigate to Expense Entry page
      - Labels:
          1. welcome
          2. calculataion
                a. budget
                b. expense
                c. balance
      - Image:
          1. piggy bank
  
  * Expense Entry page:
      - Navigatiion
          1. <- back button: navigate to previous page
      - Entry:
          1. Date picker -> default today's date
          2. Expense Name -> Alphabet keyboard
          3. Expense -> numeric keyboard
      - Dropdown:
          1. Category
      - Button :
          1. Save -> save data as a file
          2. Cancel -> delete file if file is exsiting, otherwise clear input
          
  * Budget page:
      - Navigatiion
          1. <- back button: navigate to previous page
      - Editor:
          1. input budget -> numeric keyboard (zero allows)          
      - Button :
          1. Save -> save data as a file (currently only allow user to save one budge file , after file is created overwrite the file)
          2. Cancel -> delete file if file is exsiting, otherwise clear input
          
  * Expense List page:
      - Navigation:
          1. <- back button: navigate to previous page
          2. +Expense button : navigate to Expense Entry page
          3. Home button : navigate to Home page
          4. Expese textcell: navigate to Expense Entry page
      - ListView:
          1. A list of expenses that are saved from Eexpense Entry page
