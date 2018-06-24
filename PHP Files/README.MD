# PHP Files
In this folder, you'll find the PHP files needed to display BOINC Tasks in your website.

There are two (2) versions you can use:

## all_boinc_tasks.php
This file will return a formatted table showing all BOINC Tasks with a column showing to which host the tasks belogs to.  

You can see an example here: [https://moisescardona.me/BOINC/all_boinc_tasks.php](https://moisescardona.me/BOINC/all_boinc_tasks.php)

## boinc_tasks_per_machine.php
This file will show a list of machines that have BOINC Tasks followed by a table for each host. This provides a better 
organization. You can click a machine in the list to go directly to that table.

You can see an example here: [https://moisescardona.me/BOINC/boinc_tasks_per_machine.php](https://moisescardona.me/BOINC/boinc_tasks_per_machine.php)

# Dependencies
The files uses **tablesorter**. You can get it here: [https://github.com/Mottie/tablesorter](https://github.com/Mottie/tablesorter)

You'll need to change the location of the js and css files in the scripts if you place tablesorter in another folder 
that's different from where the PHP files are located
# Embedding the code in your website.
You can simply copy and paste the code into your site. All you need to do is modify the location of the **config.php** 
file and the location of tablesorter.
You can use either file to embed them to your website in a neatly formatted way.

Here, you can see the result of the **boinc_tasks_per_machine.php** file embedded into my BOINC Statistics page in my 
personal website: [https://moisescardona.me/BOINCStatistics](https://moisescardona.me/BOINCStatistics)

**Enjoy!**