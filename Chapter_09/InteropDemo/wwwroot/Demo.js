function helloFunction() {
    alert("Hello Blazor Web Assembly");
}

function multiplyNumbers(a, b) {
    return a * b;
}

window.reverseString = function (input) {
    // Call the C# method using DotNet.invokeMethodAsync
    DotNet.invokeMethodAsync("InteropDemo", "InteropReverse", input)
        .then(function (result) {
            alert(result);
        });
}

//Chart demo
window.showChart = (chartType, dataOptions) => {
    var ctx = document.getElementById('myChart').getContext('2d');
    var options = {
        type: chartType,
        data: {
            labels: dataOptions.labels,
            datasets: [{
                label: dataOptions.label,
                data: dataOptions.data,
                backgroundColor: dataOptions.color,
                borderColor: dataOptions.color,
                fill: dataOptions.fill
            }]
        }
    };
    new Chart(ctx, options);
}

// JavaScript function
// JavaScript function
window.displayObject = function (myObject) {
    // Access properties directly
    console.log("Name:", myObject.Name);
    console.log("Age:", myObject.Age);
};

