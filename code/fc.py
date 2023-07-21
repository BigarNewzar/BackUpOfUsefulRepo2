from collections import deque
from time import time


def fc_entail(kb, q):
    agenda = deque([])
    inferred = {}
    count = {}
    for clause in kb:
        if '=>' not in clause:
            agenda.append(clause)
            inferred[clause] = False
        else:
            c = clause.split(' => ')
            inferred[c[1]] = False
            prem = c[0].split(' & ')
            count[clause] = len(prem)
            for s in prem:
                inferred[s] = False

    while agenda:
        p = agenda.popleft()
        if p == q:
            print({sym for sym in inferred.keys() if inferred[sym]})
            return True
        if not inferred[p]:
            inferred[p] = True
            for clause in kb:
                if '=>' not in clause:
                    continue
                c = clause.split(' => ')
                prem = c[0].split(' & ')
                if p in prem:
                    count[clause] -= 1
                    if count[clause] == 0:
                        agenda.append(c[1])

    return False


KB = {'p2 => p3', 'p3 => p1', 'c => e', 'b & e => f', 'f & g => h', 'p1 => d', 'p1 & p3 => c', 'a', 'b', 'p2'}
Q = 'p'
OPS = {'~', '&', '||',  '=>', '<=>'}  # In order of precedence

t0 = time()
ans = fc_entail(KB, Q)
t1 = time()
print(f'Computed = {ans} in {t1 - t0} seconds.')
