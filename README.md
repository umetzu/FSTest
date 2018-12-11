# FSTest


Summary: Write code to consume data in a CSV file, and generate reports.

You may use any language, libraries or tools you want, as long as you will be
able to demonstrate your solution in person. Code that you can email to the
interviewers ahead of time usually works best, but other means of
demonstration, such as a laptop with the necessary tools loaded, would be fine
as well.

(Please confirm that we've received your code submission, since our email
 gateway will often remove attachments. We've found a public GitHub repository
 to be the safest bet.)

Input Specification: CSV file. First line is a header. Columns are:
    TXN_DATE - date transaction took place
    TXN_TYPE - type of transaction (BUY/SELL)
    TXN_SHARES - number of shares affected by transaction
    TXN_PRICE - price per share
    FUND - name of fund in which shares are transacted
    INVESTOR - name of the owner of the shares being transacted
    SALES_REP - name of the sales rep advising the investor

Output Specification:

    1. Provide a Sales Summary:
        For each Sales Rep, generate Year to Date, Month to Date, Quarter to
        Date, and Inception to Date summary of cash amounts sold across all
        funds.

    2. Provide an Assets Under Management Summary:
        For each Sales Rep, generate a summary of the net amount held by
        investors across all funds.

    3. Break Report:
        Assuming the information in the data provided is complete and accurate,
        generate a report that shows any errors (negative cash balances,
        negative share balance) by investor.

    4. Investor Profit:
        For each Investor and Fund, return net profit or loss on investment.

Be prepared to discuss:

    Testing strategies
    Difficulties you had and how you solved them

Suggestion:

    Your code should be correct first, have good style and comments second, and
    then be clever/fast as a distant third.

Who to contact when you have questions:

    Andrew Barnett <andrew.barnett@fsinvestments.com>
    Jason Stelzer <jason.stelzer@fsinvestments.com>
