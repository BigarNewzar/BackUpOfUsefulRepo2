import sys

#basically call the relevant engines inside these sections
#and then ensure that the engines provide output in dictionary form
#and then pass them to these dictionaries in place of the current stub information


def tt(output_dictionary):
    #stub info passed to dictionary
    output_dictionary = {"Yes_or_No" : "Number of models of KB" }
    
    return output_dictionary

def fc(output_dictionary):
    #stub info passed to dictionary
    output_dictionary = {"Yes_or_No" : "Sequence of nodes to FC" }
    
    return output_dictionary

def bc(output_dictionary):
    #stub info passed to dictionary
    output_dictionary = {"Yes_or_No" : "Sequence of Nodes to BC" }
    
    return output_dictionary

def choose_engine(method, output_dictionary):
    if(method.lower() == "tt"):
        output_dictionary = tt(output_dictionary)
        return output_dictionary
    
    elif(method.lower() == "fc"):
        output_dictionary = fc(output_dictionary)
        return output_dictionary
    
    elif(method.lower() == "bc"):
        output_dictionary = bc(output_dictionary)
        return output_dictionary
    else:
        output_dictionary = {}
        print("Engine does not exist. Please ensure that the engine is named as TT, FC or BC")
        
        #return output_dictionary
        
        #NOT SURE WHERE TO RETURN NOTHING TO DICTIONARY OR USE THE PASS THINGY...ask her what pass actually does
    pass


def main():
    
    method_name=str(sys.argv[1])
    file_name=str(sys.argv[2])
    # Will need to pass them to relevant sanitizer or 
    # pharsers before passing them into these variables

    output_dictionary ={}




    output_dictionary = choose_engine(method_name, output_dictionary)
    print(output_dictionary)

main()