import string
import random

def make_random_single_symbol():
            a=random.choices(string.ascii_lowercase)
            b=random.randint(0,9)        
            if(b==0):
                    c=str(a[0])            
            else:
                    c=str(a[0])+str(b)
            """These are testing stuff
                print(c)
            """     
            return c   

def make_random_symbols(count,prepoTracklist):
        for x in range(count):
            c = make_random_single_symbol()                       
            prepoTracklist.append(c)

        return prepoTracklist
        
def make_random_single_horned(count, prepoTracklist, templist, case1):
            for y in range(count):            
                templist = random.sample(prepoTracklist,2)
                k = templist[0]
                i = templist[1]        
            
                """These are testing stuff
                print(k, "=>",i, "; ")
                """
            
                case1.append(k + " => " + i + "; ")
            return case1

def make_random_conjuction_horned(count, prepoTracklist, templist, case1):
            for z in range(count):
                templist = random.sample(prepoTracklist,3)
                k = templist[0]
                i = templist[1]
                j = templist[2]

                """These are testing stuff
                print(k, "&",j,"=>",i, "; ")
                """
            
                case1.append(k + "&" + j + " => " + i + "; ")
            return case1

def list_out_terminal(prepoTracklist, case1):
            for l in prepoTracklist:
                """These are testing stuff
                print(l, ";")   
                """
                case1.append(l + "; ")
            return case1

def normal(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testNormal"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)
    
def no_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testNoTell"+str(x)+".txt",'w')   
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []                
        
        """
        n determines how many prepositions will be made
        
        """         
        n = random.randint(3,20)        

        prepoTracklist = make_random_symbols(n, prepoTracklist)       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """
        f.write("TELL \n")        
        f.write("\nASK\n")
        f.write(k)

def no_ask(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testNoASK"+str(x)+".txt",'w')   
        
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        
        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        
def ask_not_in_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testAskNotInTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = make_random_single_symbol()

        while k in prepoTracklist:
             k = make_random_single_symbol()

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_terminal_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlyTerminalTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
       

        prepoTracklist = make_random_symbols(n, prepoTracklist)
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_single_horned_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlySingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)
        
        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)        
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_conjunction_horned_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlyConjunctionHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
               

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_terminal_and_single_horned_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlyTerminalAndSingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)        

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)        
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_terminal_and_conjuction_horned_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlyTerminalAndConjunctionHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
       
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)
       
        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        
        case1 = list_out_terminal(prepoTracklist, case1)
       

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)

def only_conjuction_and_single_horned_tell(file_count):
    """
        Exisiting info will get overridden by this, so beware. The method below will basically make and input stuff to files
        f is basically for file

        filecount will be used to determine how many files will be created
        
    """    

    for x in range (file_count):

        """
        f will be used to make file. Here it will make files with names test[x].txt where x is a number 
        Note: "[" and "]" used above was only to emphasize and actual file name will be more like test4.txt or smth
        """

        f = open("testOnlyConjunctionAndSingleHornedTell"+str(x)+".txt",'w')   
        
        
        """
        PrepoTrackList will keep track of all the prepositions made for that file
        case1 will be used to store all the horn clauses and prepositions and will be passed to that file
        templist will be used to juggle around the lists accordingly for that file
        """ 

        prepoTracklist = []    
        case1 = []
        templist = []
        
        
        """
        n determines how many prepositions will be made
        m determines how many "a => b;" statements will be made
        o determines how many "a&b => c;" statements will be made
        """   
        
   
       
        n = random.randint(3,20)
        m = random.randint(1,30)
        o = random.randint(1,30)

        prepoTracklist = make_random_symbols(n, prepoTracklist)

        case1 = make_random_single_horned(m, prepoTracklist, templist, case1)

        case1 = make_random_conjuction_horned(o, prepoTracklist, templist, case1)
        

        """These are testing stuff
        print("TELL")
        print(case1)   
        print("ASK")
        """

        k = random.choice(prepoTracklist)

        """These are testing stuff
        print(k)
        """
    
        """
        The section below will write the information to the file
        """

        f.write("TELL \n")
        for c in case1:
            f.write(c)
        f.write("\nASK\n")
        f.write(k)


def choose_edge_case(number,file_count):
    if number == 1:        
        normal(file_count)        
    if number == 2:
        no_tell(file_count)
    if number == 3:
        no_ask(file_count)
    if number == 4:
        ask_not_in_tell(file_count)
    if number == 5:
        only_terminal_tell(file_count)
    if number == 6:
        only_single_horned_tell(file_count)
    if number == 7:
        only_conjunction_horned_tell(file_count)
    if number == 8:
        only_terminal_and_single_horned_tell(file_count)
    if number == 9:
        only_terminal_and_conjuction_horned_tell(file_count)
    if number == 10:
        only_conjuction_and_single_horned_tell(file_count)


def main():
       

        print("Which type of test would you like to perform:")
        print("1.Standard file setup")
        print("2.Set up file with no TELL info")
        print("3.Set up file with no ASK info")
        print("4.Set up file with ASK info not exisitng in TELL info")
        print("5.Set up file with only terminal nodes in TELL info")
        print("6.Set up file with only single horned clause info")
        print("7.Set up file with only Conjuction horned clause info")
        print("8.Set up file with only single horned clause and terminal info")
        print("9.Set up file with only Conjuction horned clause and terminal info")
        print("10.Set up file with only Conjuction horned clause and single horned clause info")
        
        case_number = int(input("Please choose the number for the test type you want: "))
        file_number = int(input("Please say the number of test files you want to make: "))

        choose_edge_case(case_number,file_number)

       

        print("All files have been made! Press Enter to exit!")
        input()

if __name__ == "__main__":
    main()
