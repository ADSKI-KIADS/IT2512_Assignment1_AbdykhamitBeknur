# IT2512_Assignment1_AbdykhamitBeknur

Which parts of the program are imperative?
ReadDayType(), ReadTicketType(), ReadInput(), AgeOrStudentDiscount(), Main()
Which functions are pure?
AgeOrStudentDiscount(), ApplyPricingRule(), CalculateFinalPrice()
Where do side effects remain?
ReadDayType(), ReadTicketType(), ReadInput(), Main()
Why is TryParse preferred to Parse for user input?
"Parse" throws exceptions on invalid input, "TryParse" doesn't. Cleaner control flow, no "try catch" boilerplate needed
