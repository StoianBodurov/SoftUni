from collections import deque

customers = deque([int(el) for el in input().split(', ')])
taxis = [int(el) for el in input().split(', ')]

total_time = 0

while len(customers) > 0 and len(taxis) > 0:
    current_customer_time = customers.popleft()
    current_taxi_time = taxis.pop()
    if current_customer_time <= current_taxi_time:
        total_time += current_customer_time
    else:
        customers.appendleft(current_customer_time)

if not customers:
    print('All customers were driven to their destinations')
    print(f'Total time: {total_time} minutes')
else:
    print('Not all customers were driven to their destinations')
    print(f"Customers left: {', '.join(str(el) for el in customers)}")