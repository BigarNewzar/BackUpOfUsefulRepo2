from collections import deque
from time import time


def bc(q, inferred, clauses):
    if q in inferred:
        return True
    for (prem, conc) in clauses.items():
        if q == conc:
            syms = prem.split(' & ')
            for s in syms:
                if not bc(s, inferred, clauses):
                    return False
                print(s)
            return True
    return False


KB = {'p2 => p3', 'p3 => p1', 'c => e', 'b & e => f', 'f & g => h', 'p1 => d', 'p1 & p3 => c', 'a', 'b', 'p2'}
Q = 'd'
OPS = {'~', '&', '||',  '=>', '<=>'}  # In order of precedence
# print(bc_entail(KB, Q))


def bc_entail(kb, q):
    inferred = set()
    clauses = {}
    for clause in kb:
        if '=>' not in clause:
            inferred.add(clause)
        else:
            clause = clause.split(' => ')
            clauses[clause[0]] = clause[1]
    if bc(q, inferred, clauses):
        print(q)
        return True
    else:
        return False


t0 = time()
ans = bc_entail(KB,Q)
t1 = time()
print(f'Computed = {ans} in {t1 - t0} seconds.')
