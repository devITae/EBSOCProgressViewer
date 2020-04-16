# EBS OC ProgressViewer
EBS 온라인 클래스 진도율을 일괄적으로 조회할 수 있는 프로그램입니다.  
진도율로 출결관리를 하는 학생들을 위해 제작되었습니다.  

최신버전 : v1.10.0 

## [다운로드 (Download)](https://github.com/devITae/EBSOCProgressViewer/releases/download/1.10.0/EBS.OC.Progress.exe)
![최초 실행시](./img/first_notice.png)
#### VB .NET 으로 제작되었으며 윈도우에서만 이용가능 합니다.
#### EBS 계정으로만 로그인이 가능합니다. (소셜로그인 미지원)
ChangeLog : https://github.com/devITae/EBSOCProgressViewer/releases  


![메인 스크린샷](./img/screenshot2.png)

# 1. 사용법
## 1.1. 학교코드 검색
0. "찾기" 버튼을 누릅니다.

![설명](./img/search_cap.png)

1. 맨위 검색창에 학교 이름을 입력합니다.

2. 옆의 "검색" 버튼을 클릭합니다.

3. 자신의 학교 이름을 클릭합니다.

4. "선택하기" 버튼을 누르면 자동으로 코드가 입력됩니다.

## 1.2. 설명

0. "찾기" 버튼을 통해 학교를 검색하여 학교코드를 찾을 수 있습니다.  
EBS 서버가 불안정할 때 검색이 되지 않는 경우가 있습니다. 자세한 내용은 [아래참고](#22-100-이지만-표시가-되는-경우)

1. 클래스 목록에는 자신이 가입한 클래스**만** 표시됩니다.

2. 로그인하면 학습중인 강의들의 진도율이 일괄적으로 목록에 표시됩니다.

3. 이 프로그램은 사용자의 개인정보를 탈취하지 않습니다. 소스코드를 참고해주세요. [아래참고](#3-소스코드)

4. 보안상 비밀번호 저장 기능은 지원하지 않습니다. (급하게 만드느라..)

5. EBS의 자체 오류로 인해 진도율이 100%인데도 목록에 표시될 수 있습니다.

## 1.3 주의사항

1. **학습중(진도율 100% 이하)** 인 강의들만 목록만 표시됩니다.

2. 진도율 100%를 달성한 강의들은 **학습완료** 처리 되었으므로 목록에 표시되지 **않습니다.**

3. 본 사항을 분명히 숙지하시고, 문제가 생기지 않도록 주의하시기 바랍니다.

# 2. EBS 자체 오류 보고
아래 사항들은 프로그램의 문제가 아닌 EBS OC 사이트 자체에서 발생하는 오류들입니다.

## 2.1. 학교코드 찾기
EBS 서버가 불안정 할 때 학교코드 검색이 간혹가다 되지 않습니다. 그럴 때 쓰는 방법입니다.

1. <a href="https://oc.ebssw.kr/" target="_blank">https://oc.ebssw.kr/</a> 에 들어가서 자신의 학교를 선택하고 **학교가기**를 누릅니다.

	![학교 선택](./img/selectSch.PNG)

2. 새로 접속된 페이지의 주소를 보면 아래와 같이 영어와 **숫자 5자리**가 보입니다.

	***schulCcode=00000***

	그 **숫자 5자리**가 바로 **학교코드** 입니다.
3. 이제 프로그램에서 학교코드를 칸에 기입해주세요! (자동저장 됩니다!)

	![학교코드 칸](./img/schbox.PNG)
	
4. 이제 로그인 하면 됩니다!

## 2.2. 100% 이지만 표시가 되는 경우
EBS 사이트에서 발생한 오류이며 사이트에서도 동일하게 뜹니다.  
이 현상은 진도가 2개로 복제되어 생김으로 인해 발생하는데, 복제되어도 어느 걸로 듣던지 오직 하나의 항목만 학습완료로 인정되는 경우입니다.  

# 3. 소스코드
이 프로그램의 소스 코드를 공개하고 있습니다.  
https://github.com/devITae/EBSOCProgressViewer/releases 에서 다운 받을 수 있습니다.  

직접 기능을 추가해보시나, 이 코드를 분석해보셔도 좋습니다.  

하지만 제가 그렇게 코딩을 잘하지는 못한다는 점과 급하게 짠 탓에 심각한 가독성과 주석들은 감안해주세요 ㅠ  

다만 이것을 이용해 악용하지 말아주셨으면 좋겠습니다.
