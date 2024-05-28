
function TestPrint() {
    return "test";
}

var currentChart;
function DrawEnvironment(GoalLocations, StartLocationData, ObsticalLocations, MazeSize) {
    var ctx = document.getElementById('ChartHolder');

    mazeSizeX = JSON.parse(MazeSize);
    mazeSizeY = JSON.parse(MazeSize);

    // Pulling for the new data
    var goalData = JSON.parse(GoalLocations);
    var obstacalData = JSON.parse(ObsticalLocations);
    var startData = JSON.parse(StartLocationData);

    var ScatterData = {
        datasets: [{
            label: "Goal Node",
            data: goalData,

            backgroundColor: 'rgb(255, 255, 0)',
            showLine: false,
            pointStyle: 'star',
            radius: 15,
        },
        {
            label: "Obs Node",
            data: obstacalData,

            backgroundColor: 'rgb(136, 8, 8) ',
            showLine: false,
            pointStyle: 'circle',
            radius: 15,
        },
        {
            label: "Start  Node",
            data: startData,

            backgroundColor: 'rgb(255, 99, 0)',
            showLine: false,
            pointStyle: 'star',
            radius: 15,
            borderWidth: 4
        }
        ],
    };

    var chartConfig = {
        type: 'scatter',
        data: ScatterData,
        options: {

            tension: 0.2,
            scales: {

                x: {
                    min: 0,
                    max: mazeSizeX,
                    type: 'linear',
                    position: 'bottom',
                    ticks: {
                        stepSize: 1
                    },

                },
                y: {
                    min: 0,
                    max: mazeSizeY,
                    type: 'linear',
                    ticks: {
                        stepSize: 1
                    },

                },

            }
        }
    }

    if (currentChart) {
        currentChart.destroy();
        currentChart = new Chart(ctx, chartConfig);
    } else {
        currentChart = new Chart(ctx, chartConfig);
    }
}

function DrawAgentPath(AgentPath, GoalLocations, StartLocationData, ObsticalLocations, MazeSize) {

    var ctx = document.getElementById('ChartHolder');

    mazeSizeX = JSON.parse(MazeSize);
    mazeSizeY = JSON.parse(MazeSize);

    // Pulling for the new data
    var pathData = JSON.parse(AgentPath);
    var goalData = JSON.parse(GoalLocations);
    var obstacalData = JSON.parse(ObsticalLocations);
    var startData = JSON.parse(StartLocationData);

    var ScatterData = {
        datasets: [{
            label: "Path Node",
            data: pathData,

            backgroundColor: 'rgb(255, 99, 132)',
            showLine: true,
            pointStyle: 'triangle',
            radius: 5,


        }, {
            label: "Goal Node",
            data: goalData,

            backgroundColor: 'rgb(255, 99, 132)',
            showLine: true,
            pointStyle: 'circle',
            radius: 15,
        }, {
            label: "Obs Node",
            data: obstacalData,

            backgroundColor: 'rgb(255, 99, 132)',
            showLine: true,
            pointStyle: 'circle',
            radius: 15,
        }, {
            label: "Start  Node",
            data: startData,

            backgroundColor: 'rgb(255, 99, 132)',
            showLine: true,
            pointStyle: 'star',
            radius: 15,
        }
        ],
    };

    var chartConfig = {
        type: 'scatter',
        data: ScatterData,
        options: {

            tension: 0.2,
            scales: {

                x: {
                    min: 0,
                    max: mazeSizeX,
                    type: 'linear',
                    position: 'bottom',
                    ticks: {
                        stepSize: 1
                    },

                },
                y: {
                    min: 0,
                    max: mazeSizeY,
                    type: 'linear',
                    ticks: {
                        stepSize: 1
                    },

                },

            }
        }
    }

    if (currentChart) {
        currentChart.destroy();
        currentChart = new Chart(ctx, chartConfig);
    } else {
        currentChart = new Chart(ctx, chartConfig);
    }


};

function generateList(n) {
    let list = [];
    for (let i = 0; i <= n; i++) {
        list.push(i);
    }
    return list;
}


// This will become the show fitness barchart for the ALPHA
// Need to destroy and rebuild canvas on click
function DrawFitnessByStep(fitnessByStepData) {

    var ctx = document.getElementById('ChartHolder');

    var data = JSON.parse(fitnessByStepData);

    var neededLabels = data.length;
    var newLabels = generateList(neededLabels);

    var data = {
        labels: newLabels,
        datasets: [{
            label: 'Fitness By Step',
            data: data,

            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.5,
            showLine: true,
        }]
    };

    var chartConfig = {
        type: 'line',
        data: data,
        options: {
            scales: {
                x: {
                    title: {
                        display: true,
                        text: 'Step'
                    }
                },
                y: {
                    title: {
                        display: true,
                        text: 'Fitness'
                    }
                }
            }
        }
    };

    if (currentChart) {
        currentChart.destroy();
        currentChart = new Chart(ctx, chartConfig);
    } else {
        currentChart = new Chart(ctx, chartConfig);
    }

};


function UpdateVisableChartData(AvgFitnessByGenerationIsVisable, AvgStepsByGenerationIsVisable) {

    var FitnessByGeneration = currentChart.data.datasets[0];
    var StepsByGeneration = currentChart.data.datasets[1];

    FitnessByGeneration.hidden = AvgFitnessByGenerationIsVisable;
    StepsByGeneration.hidden = AvgStepsByGenerationIsVisable;

    currentChart.update();
}


function showGenerationDataGraph(AvgFitnessByGenerationIsVisable, AvgStepsByGenerationIsVisable, AvgFitnessPerGenJson, AvgStepPerGenJson, NumGenerationsJson) {

    var ctx = document.getElementById('ChartHolder');

    var FitnessPerGenData = JSON.parse(AvgFitnessPerGenJson);
    var StepsPerGen = JSON.parse(AvgStepPerGenJson);
    var NumGenerations = JSON.parse(NumGenerationsJson);

    var Labales = generateList(NumGenerations);

    const data = {
        labels: Labales,
        datasets: [{
            hidden: AvgFitnessByGenerationIsVisable,
            type: 'bar',
            label: 'Bar Dataset',
            data: FitnessPerGenData,
            borderColor: 'rgb(255, 99, 132)',
            backgroundColor: 'rgba(255, 99, 132, 0.2)'
        }, {
            hidden: AvgStepsByGenerationIsVisable,
            type: 'line',
            label: 'Line Dataset',
            data: StepsPerGen,
            fill: false,
            borderColor: 'rgb(54, 162, 235)'
        }]
    };

    const chartConfig = {
        type: 'scatter',
        data: data,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    };

    if (currentChart) {
        currentChart.destroy();
        currentChart = new Chart(ctx, chartConfig);
    } else {
        currentChart = new Chart(ctx, chartConfig);
    }

};