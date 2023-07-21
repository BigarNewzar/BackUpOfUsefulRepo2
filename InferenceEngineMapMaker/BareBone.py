import string
import random

def make_random_single_symbol():
    a=random.choices(string.ascii_lowercase)
    b=random.randint(0,9)        
    if(b==0):
            c=str(a[0])            
    else:
            c=str(a[0])+str(b)                   
    return c   

def make_random_literals_for_KB():
    x=random.randint(0,9) 
    if (x > 5):
           a="~".join(random.choices(string.ascii_lowercase))
    else:
           a=random.choices(string.ascii_lowercase)
    b=random.randint(0,9)        
    if(b==0):
            c=str(a[0])            
    else:
            c=str(a[0])+str(b)                   
    return c 

def make_only_positive_literals_for_KB():
    
    a=random.choices(string.ascii_lowercase)
    b=random.randint(0,9)        
    if(b==0):
            c=str(a[0])            
    else:
            c=str(a[0])+str(b)                   
    return c

def make_only_negative_literals_for_KB():
   
    a="~".join(a=random.choices(string.ascii_lowercase))
    b=random.randint(0,9)        
    if(b==0):
            c=str(a[0])            
    else:
            c=str(a[0])+str(b)                   
    return c
