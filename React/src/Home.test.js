import { render } from "@testing-library/react";
import Home  from "./Home";
import '@testing-library/jest-dom/extend-expect'
test("test 1",()=>{
   const{getByTestId}= render(<Home/>);
   const headerEl = getByTestId("rooot");
   expect(headerEl.textContent).toBe("Welcome to Pharamacy Medicine Supply Management ")
})
test("test ",()=>{
   const{getByTestId} = render(<Home/>);
   const cardEL = getByTestId("rt");
   expect(cardEL.textContent).toBe("100% Genuine Medicine")
    

})

test("test 1/",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt");
    expect(cardEL.textContent).toBe("100% Genuine Medicine")
     
 
 })

 test("test 2",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt1");
    expect(cardEL.textContent).toBe("Most Trusted Online Medical Store Of India")
     
 
 })

 test("test 3",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt2");
    expect(cardEL.textContent).toBe("Fastest Home Delivery Of Your Order")
     
 
 })

 test("test 4",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt3");
    expect(cardEL.textContent).toBe("Largest Online Pharmacy In India")
     
 
 })
 test("test 5",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt4");
    expect(cardEL.textContent).toBe("Best Pharmacologist Available To Check Medicine Interactions")
     
 
 })
 test("test 6",()=>{
    const{getByTestId} = render(<Home/>);
    const cardEL = getByTestId("rt5");
    expect(cardEL.textContent).toBe("Additional Services I Will Receive")
     
 
 })