﻿$(document).ready(function () {
    var myElem = document.getElementById('chart1');
    if (myElem !== null) {
        Highcharts.chart('chart1',
            {
                title: {
                    text: 'Solar Employment Growth by Sector, 2010-2016'
                },

                subtitle: {
                    text: 'Source: thesolarfoundation.com'
                },

                yAxis: {
                    title: {
                        text: 'Number of Employees'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                plotOptions: {
                    series: {
                        label: {
                            connectorAllowed: false
                        },
                        pointStart: 2010
                    }
                },

                series: [
                    {
                        name: 'Installation',
                        data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
                    }, {
                        name: 'Manufacturing',
                        data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
                    }, {
                        name: 'Sales & Distribution',
                        data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
                    }, {
                        name: 'Project Development',
                        data: [null, null, 7988, 12169, 15112, 22452, 34400, 34227]
                    }, {
                        name: 'Other',
                        data: [12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111]
                    }
                ]

            });
    };
    var myElem = document.getElementById('chart2');
    if (myElem !== null) {
        Highcharts.chart('chart2',
            {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Column chart with negative values'
                },
                xAxis: {
                    categories: ['Apples', 'Oranges', 'Pears', 'Grapes', 'Bananas']
                },
                credits: {
                    enabled: false
                },
                series: [
                    {
                        name: 'John',
                        data: [5, 3, 4, 7, 2]
                    }, {
                        name: 'Jane',
                        data: [2, -2, -3, 2, 1]
                    }, {
                        name: 'Joe',
                        data: [3, 4, 4, -2, 5]
                    }
                ]
            });
   };
    var myElem = document.getElementById('chart3');
    if (myElem !== null) {
        Highcharts.chart('chart3',
            {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Browser market shares in January, 2018'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [
                    {
                        name: 'Brands',
                        colorByPoint: true,
                        data: [
                            {
                                name: 'Chrome',
                                y: 61.41,
                                sliced: true,
                                selected: true
                            }, {
                                name: 'Internet Explorer',
                                y: 11.84
                            }, {
                                name: 'Firefox',
                                y: 10.85
                            }, {
                                name: 'Edge',
                                y: 4.67
                            }, {
                                name: 'Safari',
                                y: 4.18
                            }, {
                                name: 'Other',
                                y: 7.05
                            }
                        ]
                    }
                ]
            });
    };
    var myElem = document.getElementById('chart4');
    if (myElem !== null) {
        Highcharts.chart('chart4',
            {
                title: {
                    text: 'Solar Employment Growth by Sector, 2010-2016'
                },

                subtitle: {
                    text: 'Source: thesolarfoundation.com'
                },

                yAxis: {
                    title: {
                        text: 'Number of Employees'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                plotOptions: {
                    series: {
                        label: {
                            connectorAllowed: false
                        },
                        pointStart: 2010
                    }
                },

                series: [
                    {
                        name: 'Installation',
                        data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
                    }, {
                        name: 'Manufacturing',
                        data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
                    }, {
                        name: 'Sales & Distribution',
                        data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
                    }, {
                        name: 'Project Development',
                        data: [null, null, 7988, 12169, 15112, 22452, 34400, 34227]
                    }, {
                        name: 'Other',
                        data: [12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111]
                    }
                ]

            });
    };
    var myElem = document.getElementById('chart5');
    if (myElem !== null) {
        Highcharts.chart('chart5',
            {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Column chart with negative values'
                },
                xAxis: {
                    categories: ['Apples', 'Oranges', 'Pears', 'Grapes', 'Bananas']
                },
                credits: {
                    enabled: false
                },
                series: [
                    {
                        name: 'John',
                        data: [5, 3, 4, 7, 2]
                    }, {
                        name: 'Jane',
                        data: [2, -2, -3, 2, 1]
                    }, {
                        name: 'Joe',
                        data: [3, 4, 4, -2, 5]
                    }
                ]
            });
    };
    var myElem = document.getElementById('chart6');
    if (myElem !== null) {
        Highcharts.chart('chart6',
            {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Browser market shares in January, 2018'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [
                    {
                        name: 'Brands',
                        colorByPoint: true,
                        data: [
                            {
                                name: 'Chrome',
                                y: 61.41,
                                sliced: true,
                                selected: true
                            }, {
                                name: 'Internet Explorer',
                                y: 11.84
                            }, {
                                name: 'Firefox',
                                y: 10.85
                            }, {
                                name: 'Edge',
                                y: 4.67
                            }, {
                                name: 'Safari',
                                y: 4.18
                            }, {
                                name: 'Other',
                                y: 7.05
                            }
                        ]
                    }
                ]
            });
    };
});

